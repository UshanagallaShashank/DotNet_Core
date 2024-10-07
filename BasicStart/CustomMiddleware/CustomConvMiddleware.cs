using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BasicStart.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomConvMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomConvMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Query.ContainsKey("firstName") && httpContext.Request.Query.ContainsKey("LastName"))
            {
                var name = httpContext.Request.Query["firstName"] + " " + httpContext.Request.Query["LastName"];
                 await httpContext.Response.WriteAsync(name);
            }
             await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomConvMiddleware>();
        }
    }
}
