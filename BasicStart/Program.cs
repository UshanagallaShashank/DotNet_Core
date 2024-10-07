using BasicStart.CustomMiddleware;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddlewareClass>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");



////-------JQuery Handling-----------------
//app.Run(async (HttpContext context) =>
//{
//    context.Response.Headers["Content-type"] = "text/html";
//    if (context.Request.Method == "GET")
//    {
//        if (context.Request.Query.ContainsKey("id"))
//        {
//            string id = context.Request.Query["id"];
//            await context.Response.WriteAsync($"<p>{id}</p>");
//        }
//    }
//}
//);


//-----------------------Request Headers-------------------------
//app.Run(async (HttpContext context) =>
//{
//    context.Response.Headers["Content-Type"] = "text/html";

//    if (context.Request.Headers.ContainsKey("User-Agent"))
//    {
//        string userAgent = context.Request.Headers["User-Agent"];
//        await context.Response.WriteAsync($"<p>{userAgent}</p>");
//    }
//}

//);


//---------------Run----------------
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hello");
//});

//----------------MiddlewareChain--------------


//middleware1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello");
    await next(context);
});


//middleware2
//app.UseMiddleware<MyCustomMiddlewareClass>();

////custom middleware extension
//app.UseCustomMethod();


//Conventional middleware
//app.UseMiddleware();


//UseWhen Middleware
app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync(" got the values  UseWhen");
            await next();
        });
    });





//middleware3
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("HelloAgain");
});




app.Run();