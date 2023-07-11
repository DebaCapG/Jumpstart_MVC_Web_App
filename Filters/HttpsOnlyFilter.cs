using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Jumpstart_MVC_Web_App.Filters
{
    public class HttpsOnlyFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.IsHttps)
                context.Result = new ForbidResult();
        }
    }
}
