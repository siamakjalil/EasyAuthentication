using EasyAuthentication.Constants;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuthentication.Tools
{
    public static class JwtHandler
    {
        public static Guid? GetUserId(this string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            var userId = securityToken.Claims.FirstOrDefault(c => c.Type == CustomClaimTypes.Uid)?.Value;
            if (userId == null)
            {
                return null;
            }
            return Guid.Parse(userId);
        }
        public static JwtSecurityToken ReadToken(this string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            return securityToken;
        }
    }
}
