
namespace BasicStart.CustomMiddleware
{
    public class MyCustomMiddlewareClass : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("resp from Middleware");
            await next(context);
            await context.Response.WriteAsync($"{nameof(MyCustomMiddlewareClass)}");
        }
    }
}
