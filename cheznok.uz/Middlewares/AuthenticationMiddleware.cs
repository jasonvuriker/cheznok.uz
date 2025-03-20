

using cheznok.uz.Services;

namespace cheznok.uz.Middlewares;

public class AuthenticationMiddleware(
    IUserService userService,
    ILogger<AuthenticationMiddleware> logger):IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path.StartsWithSegments("/api/Auth"))
        {
            await next(context);
            return;
        }

        var apiKey = context.Request.Headers["ApiKey"];

        if (string.IsNullOrEmpty(apiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Authentication required");

            logger.LogWarning("Invalid authorization header, {apiKey}", apiKey);
            return;
        }

        var userId = await userService.Authenticate(apiKey);

        if (userId == null || userId == 0)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Authentication required");

            return;
        }

        context.Items["UserId"] = userId;

        await next(context);
    }
}
