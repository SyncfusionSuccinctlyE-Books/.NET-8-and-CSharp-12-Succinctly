using Microsoft.AspNetCore.Diagnostics;

namespace ExceptionHandlingDemo;
public class CustomExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
        Exception ex, 
        CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = 500;
        httpContext.Response.ContentType = "text/plain";
        await httpContext.Response.WriteAsync($"Custom Exception Handler: {ex.Message}");

        return true;
    }
}
