using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using EasyAuthentication.Configurations;
using EasyAuthentication.Constants;
using EasyAuthentication.Contracts;
using EasyAuthentication.Models.Entity;
using EasyAuthentication.Models.Jwt;
using EasyAuthentication.Models.Request;
using EasyAuthentication.Models.Response;
using EasyAuthentication.Tools;

namespace EasyAuthentication.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IdentityDbContext _context;
        private readonly JwtSettings _jwtSettings; 

        public AuthenticationRepository(IdentityDbContext context, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value; 
        }
        public async Task<SendAuthCodeResponse> SendAuthCode(SendAuthCode sendAuthCode)
        {
            var authKey = 5.GenerateAuthCode();
            var model = _context.Users.FirstOrDefault(u => 
                (string.IsNullOrEmpty(sendAuthCode.MobileNumber) || u.MobileNumber == sendAuthCode.MobileNumber) &&
                (string.IsNullOrEmpty(sendAuthCode.Email) || u.Email == sendAuthCode.Email));
            if (model == null)
            { 
                model = new User()
                {
                    IsActive = true,
                    MobileNumber = sendAuthCode.MobileNumber,
                    ActiveCode = authKey,
                    UniqueId = Guid.NewGuid(),
                    Id = Guid.NewGuid(),
                    Email = sendAuthCode.Email
                };
                _context.Users.Add(model);
            }
            else
            { 
                if (!string.IsNullOrEmpty(model.Password)&& sendAuthCode.ForceSend != true)
                {
                    return new SendAuthCodeResponse()
                    {
                        UserId = model.Id,
                        UserUniqueId = model.UniqueId,
                        HasPass = true,
                    };
                }
                model.ActiveCode = authKey;
                _context.Users.Update(model);
            }
            await _context.SaveChangesAsync();
            return new SendAuthCodeResponse()
            {
                ActivationCode = model.ActiveCode
            };

        }

        public async Task<LoggedInUser> LoginByAuthCode(LoginByAuthCode loginByAuthCode, string browser, string ip)
        {
            var model = await _context.Users.FirstOrDefaultAsync(u =>
                (string.IsNullOrEmpty(loginByAuthCode.MobileNumber) || u.MobileNumber == loginByAuthCode.MobileNumber) &&
                (string.IsNullOrEmpty(loginByAuthCode.Email) || u.Email == loginByAuthCode.Email) &&
                (u.ActiveCode == loginByAuthCode.ActivationCode));
            if (model == null)
            {
                return null;
            }

            return await SetLoggedInUserModel(model,  browser, ip);
        }

        public async Task<LoggedInUser> LoginByPass(LoginByPass loginByPass, string browser, string ip)
        {
            var model = await _context.Users.FirstOrDefaultAsync(u =>
                (string.IsNullOrEmpty(loginByPass.MobileNumber) || u.MobileNumber == loginByPass.MobileNumber) &&
                (string.IsNullOrEmpty(loginByPass.Email) || u.Email == loginByPass.Email));
            if (model == null)
            {
                return null;
            }
            var pass = loginByPass.Password.EncodePassword(model.Key);
            if (pass != model.Password)
            {
                return null;
            }
            return await SetLoggedInUserModel(model, browser, ip);
        }

        public async Task<bool> SetPass(SetPass setPass)
        {
            var user = await _context.Users.FindAsync(setPass.UserId);
            if (user==null)
            {
                return false;
            }
            user.Key = 10.GenerateSalt();
            user.Password = setPass.Pass.EncodePassword(user.Key);
            if (setPass.UserType!=null)
            {
                user.UserType = setPass.UserType.Value;
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangePass(ChangePass changePass)
        {
            var user = await _context.Users.FindAsync(changePass.UserId);
            var pass = changePass.NewPass.EncodePassword(user.Key);
            if (user == null || user.Password != pass) return false;
            user.Key = 10.GenerateSalt();
            user.Password = changePass.NewPass.EncodePassword(user.Key);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;

        }

        private async Task<string> GenerateToken(User user,string browser , string ip)
        {
            var roles = await _context.UserInRoles.Include(u => u.Role).Where(u => u.IsActive && u.UserId == user.Id)
                .Select(u => u.Role.Title).ToListAsync();

            var roleClaims = new List<Claim>();

            foreach (var t in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, t));
            }

            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,user.MobileNumber),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()), 
                    new Claim(CustomClaimTypes.Uid,user.Id.ToString()),
                    new Claim(CustomClaimTypes.FirstName,user.FirstName??""),
                    new Claim(CustomClaimTypes.LastName,user.LastName?? ""),
                    new Claim(CustomClaimTypes.Email,user.Email ?? ""),
                    new Claim(CustomClaimTypes.Mobile,user.MobileNumber ?? ""),
                    new Claim(CustomClaimTypes.UserType,user.UserType.ToString()),
                } 
                .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var exp = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires:exp ,
                signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            await SaveToken(user, token, exp, browser,  ip);
            return token;
        }

        private async Task SaveToken(User user , string token , DateTime exp, string browser, string ip)
        {
            await _context.UserSessions.AddAsync(new UserSession()
            {
                UserId = user.Id,
                Browser = browser,
                DateTime = DateTime.Now,
                ExpireDateTime = exp,
                Id = Guid.NewGuid(),
                Ip = ip,
                IsActive = true,
                Token = token
            });
            await _context.SaveChangesAsync();
        }
        private async Task<LoggedInUser> SetLoggedInUserModel(User user,string browser, string ip)
        {
            return new LoggedInUser()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token =await GenerateToken(user, browser, ip),
                Id = user.Id,
                Type = user.UserType,
                NewUser = string.IsNullOrEmpty(user.FirstName),
                UserUniqueId = user.UniqueId
            };
        }
    }
}
