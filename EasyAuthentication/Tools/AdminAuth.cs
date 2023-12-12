using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using EasyAuthentication.Constants;

namespace EasyAuthentication.Tools
{

    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute() : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { };
        }
    }

    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        private WebTools _webTools;

        public ClaimRequirementFilter(WebTools webTools)
        {
            _webTools = webTools;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var userRoles = _webTools.GetUserFromClaim().Rols;
            if (userRoles.Contains(RoleNames.Admin)) return;
            context.Result = new RedirectResult("/Account/Login");
            return;
        }
    }

}
