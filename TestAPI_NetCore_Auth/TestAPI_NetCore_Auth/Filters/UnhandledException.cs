using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI_NetCore_Auth.Filters
{
    public class UnhandledException : Attribute, IExceptionFilter
    {
        public async void OnException(ExceptionContext context)
        {
            //if (context.Exception != null)
            //{
            //    byte[] data = Encoding.UTF8.GetBytes( "error:unhandled exception");
            //    context.HttpContext.Response.ContentType = "application/json";
            //    await context.HttpContext.Response.Body.WriteAsync(data,0,data.Length);

            //}
            //context.Result = new ContentResult
            //{
            //    Content = "error:unhandled exception"
            //};
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionStack = context.Exception.StackTrace;
            string exceptionMessage = context.Exception.Message;
            context.Result = new ContentResult
            {
                Content = $"error:unhandled exception"
            };
            context.ExceptionHandled = true;

        }
    }
}
