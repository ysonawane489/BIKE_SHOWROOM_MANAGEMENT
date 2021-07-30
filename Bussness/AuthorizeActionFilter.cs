using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Security.Claims;

namespace BIKE_SHOWROOM_MANAGEMENT.Bussness
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly string _permission;
        public AuthorizeActionFilter(string permission)
        {
            _permission = permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorized = CheckUserPermission(context.HttpContext.User, _permission);
            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private bool CheckUserPermission(ClaimsPrincipal user, string permission)
        {
            return permission == "Read";
        }
        public class AuthorizeAttribute : TypeFilterAttribute
        {
            public AuthorizeAttribute(string permission)
                : base(typeof(AuthorizeActionFilter))
            {
                Arguments = new[] { permission };
            }
        }

    }
}
