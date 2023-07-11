using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Jumpstart_MVC_Web_App.Filters
{
    /// <summary>
    /// It's a Result Filter class that adds a custom header before the result is rendered.
    /// </summary>
    public class ResultFilter : IResultFilter
    {       
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // Do something before the result executes.
            context.HttpContext.Response.Headers.Add("MyHeader", "This is a custom header");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Do something after the result executes.
        }
    }
}
