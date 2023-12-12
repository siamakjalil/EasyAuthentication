using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using EasyAuthentication.Constants;
using EasyAuthentication.Models.Response;

namespace EasyAuthentication.Tools
{
    public class WebTools
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WebTools(IHttpContextAccessor httpContextAccessor) =>
            _httpContextAccessor = httpContextAccessor;

        public string GetRealIp()
        {
            try
            {
                if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Headers["AR_REAL_IP"]))
                    return _httpContextAccessor.HttpContext.Request.Headers["AR_REAL_IP"];
                if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Headers["REMOTE_ADDR"]))
                    return _httpContextAccessor.HttpContext.Request.Headers["REMOTE_ADDR"];
                return _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public string GetBrowser()
        {
            try
            {
                var browser = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();
                return browser;
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public Guid? GetUserIdFromClaims()
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            if (!claimsIdentity.IsAuthenticated)
            {
                return null;
            }
            var userId = claimsIdentity.FindFirst(CustomClaimTypes.Uid)?.Value;
            return Guid.Parse(userId);
        }
        public bool IsLogin()
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            return claimsIdentity.IsAuthenticated;
        }

        public Guid? GetUserId()
        {
            return GetUserIdFromClaims();
        }

        public bool IsAdmin()
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            return claimsIdentity.FindAll(u => u.Type == ClaimTypes.Role).Any(u => u.Value.ToLower() == RoleNames.Admin.ToLower());
        }
        public LoggedInUser GetUserFromClaim()
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var type = claimsIdentity.FindFirst(CustomClaimTypes.UserType)?.Value;
            return new LoggedInUser()
            {
                FirstName = claimsIdentity.FindFirst(CustomClaimTypes.FirstName)?.Value,
                LastName = claimsIdentity.FindFirst(CustomClaimTypes.LastName)?.Value,
                MobileNumber = claimsIdentity.FindFirst(CustomClaimTypes.Mobile)?.Value,
                Type = type != null ? int.Parse(type) : 0,
                Rols = string.Join(",", claimsIdentity.FindAll(u => u.Type == ClaimTypes.Role))
            };
        }
        public string GetDisplayName()
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var firstName = claimsIdentity.FindFirst(CustomClaimTypes.FirstName)?.Value;
            var lastName = claimsIdentity.FindFirst(CustomClaimTypes.LastName)?.Value;
            var mobileNumber = claimsIdentity.FindFirst(CustomClaimTypes.Mobile)?.Value;
            return !string.IsNullOrEmpty(firstName) ? $"{firstName} {lastName}" : mobileNumber;
        }
        public void SignIn(string token)
        {
            var tokenContent = token.ReadToken();
            CookieOptions options = new CookieOptions();
            options.Expires = tokenContent.ValidTo;
            //options.SameSite = SameSiteMode.None;
            _httpContextAccessor.HttpContext.Response.Cookies.Append(CustomClaimTypes.Token, token, options);
        }
        public void SignOut()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(CustomClaimTypes.Token);
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(CustomClaimTypes.UserType);
        }
        public void SetUserTypeOnCookie(int type)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(30);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(CustomClaimTypes.UserType, type.ToString(), options);
        }
        public int GetUserType()
        {
            var type = _httpContextAccessor.HttpContext?.Request.Cookies[CustomClaimTypes.UserType] ?? "";
            return !string.IsNullOrEmpty(type) ? int.Parse(type) : 0;
        }
        public void SetCookieData(string key , string value)
        {
            var exist = GetCookieData(key);
            if (!string.IsNullOrEmpty(exist))
            {
                DeleteCookieData(key);
            }
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(30);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);
        }
        public string GetCookieData(string key)
        {
            var cookie = _httpContextAccessor.HttpContext?.Request.Cookies[key] ?? "";
            return cookie;
        }
        public void DeleteCookieData(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(CustomClaimTypes.UserType);
        }

        public string GetPath()
        {
            return _httpContextAccessor.HttpContext.Request.Path;
        }
    }
}
