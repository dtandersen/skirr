using System.Text.Json;
using Skirr.Command;

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionMiddleware(RequestDelegate next, IWebHostEnvironment hostingEnvironment)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            Console.WriteLine("Middlewarexxxxxxxxxxxxxxxxxxxxxxxxxx");
            await _next(httpContext);
            Console.WriteLine("Middlewar11111111111111111111111");
        }
        catch (InvalidDeviceException ex)
        {
            Console.WriteLine("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 400;

        var error = ((InvalidDeviceException)exception).Error;
        return context.Response.WriteAsync(JsonSerializer.Serialize(error));
    }
}

// public static class RequestCultureMiddlewareExtensions
// {
//     public static IApplicationBuilder UseRequestCulture(
//         this IApplicationBuilder builder)
//     {
//         return builder.UseMiddleware<CustomExceptionMiddleware>();
//     }
// }
