using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using NASADemo.Infrastructure.NET;

namespace NASADemo.Web.Infrastructure
{
    // More info: https://stackoverflow.com/questions/38630076/asp-net-core-web-api-exception-handling
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.InnermostException().Message);
            }
        }
    }
}