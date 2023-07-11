﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Jumpstart_MVC_Web_App.Filters
{
    public class AuthorizeActionFilter : Attribute, IAuthorizationFilter
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
            // Logic for checking the user permission goes here. 

            // Let's assume this user has only read permission.
            return permission == "Read";
        }
    }
}
