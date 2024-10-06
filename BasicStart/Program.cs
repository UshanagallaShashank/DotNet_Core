using System.IO;

var builder = WebApplication.CreateBuilder(args);
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
app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-Type"] = "text/html";
  
        if (context.Request.Headers.ContainsKey("User-Agent"))
        {
            string userAgent = context.Request.Headers["User-Agent"];
            await context.Response.WriteAsync($"<p>{userAgent}</p>");
        }
    }

);


app.Run();