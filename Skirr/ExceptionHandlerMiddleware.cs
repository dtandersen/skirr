using Skirr;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    ILogger<ExceptionHandlerMiddleware> logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment hostingEnvironment, ILogger<ExceptionHandlerMiddleware> logger)
    {
        this.logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (AlpacaException ex)
        {
            await Handle400(httpContext, ex);
        }
        catch (Exception ex)
        {
            await Handle500(httpContext, ex);
        }
        finally
        {
            logger.LogInformation($"{httpContext.Request.Method} {httpContext.Request.Path}?{httpContext.Request.QueryString} {httpContext.Response.StatusCode}");
        }
    }

    private Task Handle400(HttpContext context, AlpacaException exception)
    {
        context.Response.ContentType = "text/plain";
        context.Response.StatusCode = 400;
        return context.Response.WriteAsync(exception.Message);
    }

    private Task Handle500(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "text/plain";
        context.Response.StatusCode = 500;
        return context.Response.WriteAsync("Error");
    }
}
