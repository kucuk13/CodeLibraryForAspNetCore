using MiddlewareExample.Middlewares;

namespace MiddlewareExample.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddeleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CustomMiddleware>();
        }
    }
}
