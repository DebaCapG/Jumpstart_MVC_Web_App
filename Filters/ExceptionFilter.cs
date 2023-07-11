using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System;
using Microsoft.AspNetCore.Http;

namespace Jumpstart_MVC_Web_App.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        private readonly ILogger _logger;

        public ExceptionFilter(IHostEnvironment hostEnvironment, ILogger<ExceptionFilter> logger)
        {
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            int statusCode = (int)HttpStatusCode.OK;

            if (!context.ExceptionHandled)
            {               
                if (!_hostEnvironment.IsDevelopment())
                {
                    switch (true)
                    {
                        case bool _ when exception is UnauthorizedAccessException:
                            statusCode = (int)HttpStatusCode.Unauthorized;
                            break;


                        case bool _ when exception is InvalidOperationException:
                            statusCode = (int)HttpStatusCode.BadRequest;
                            break;


                        default:
                            statusCode = (int)HttpStatusCode.InternalServerError;
                            break;
                    }

                    _logger.LogError($"GlobalExceptionFilter: Error in {context.ActionDescriptor.DisplayName}. {exception.Message}. Stack Trace: {exception.StackTrace}");
                }
            }
            context.HttpContext.Response.StatusCode = statusCode;
            context.Result = new ObjectResult(exception.Message) { StatusCode = statusCode };
           
        }
    }
}
