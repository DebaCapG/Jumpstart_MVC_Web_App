using Microsoft.AspNetCore.Mvc.Filters;

namespace Jumpstart_MVC_Web_App.Attributes
{
    public class AddHeaderAttribute : ResultFilterAttribute
    {
        private readonly string _name;
        private readonly string[] _value;

        public AddHeaderAttribute(string name, string value)
        {
            _name = name;
            _value = new string[] { value };
        }

        public AddHeaderAttribute(string name, string[] value)
        {
            _name = name;
            _value = value;
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // Do something before the result executes.
            context.HttpContext.Response.Headers.Add(_name, _value);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            // Do something after the result executes.
        }
    }
}
