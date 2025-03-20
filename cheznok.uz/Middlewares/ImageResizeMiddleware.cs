namespace cheznok.uz.Middlewares;

public class ImageResizeMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        //if (context.Request.Path.StartsWithSegments("/StaticFiles"))
        //{
        //    var filePath = Path.GetFileName(context.Request.Path.Value);

        //    var file = Path.Combine(hostEnvironment.ContentRootPath, filePath);

        //    await next(context);
        //}

        await next(context);
    }
}
