using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empapp.Infrastructure
{
   
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class ApiSecurity : Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue
                (APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Unauthorized Access: Api Key was not provided"
                };
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetSection("Appsetting").GetSection("ApiKeyConfig").GetValue<string>("Secret");

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Unauthorized Access: Api Key is not valid"
                };
                return;
            }

            await next();
        }
    }
}
