using Grannys_yarns_API.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Grannys_yarns_API.Services;

public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;

    public TokenValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, iService service)
    {
        if (context.Request.Path.StartsWithSegments("/granny's_yarns/login"))
        {
            await _next(context);
            return;
        }

        if (context.Request.Path.StartsWithSegments("/granny's_yarns/distributors/add"))
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue("Authorization", out var token))
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Authorization header missing");
            return;
        }

        var tokenString = token.ToString().Replace("Bearer ", "");

        if (!service.ValidateToken(tokenString))
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Invalid token");
            return;
        }

        await _next(context);
    }
}