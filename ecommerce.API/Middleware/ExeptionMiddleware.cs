using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ecommerce.API.Middleware;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExeptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExeptionMiddleware> _logger;

    public ExeptionMiddleware(RequestDelegate next, ILogger<ExeptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);

        }
        catch (Exception ex)
        {
            _logger.LogError($"{ex.GetType().ToString()} : {ex.Message}");
            httpContext.Response.StatusCode = 500;

            await httpContext.Response.WriteAsJsonAsync(new { Message = ex.Message, Type = ex.GetType().ToString() });
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExeptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExeptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExeptionMiddleware>();
    }
}

