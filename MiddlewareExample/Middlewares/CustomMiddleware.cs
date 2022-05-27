using System.Diagnostics;

namespace MiddlewareExample.Middlewares
{
    public class CustomMiddleware
    {
        RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next.Invoke(context);
            watch.Stop();
            Console.WriteLine(context.Request.Scheme + 
                "://" + 
                context.Request.Host.Value + 
                context.Request.Path.Value + 
                " service executed in " + 
                watch.ElapsedMilliseconds + " ms.");
        }
    }
}
