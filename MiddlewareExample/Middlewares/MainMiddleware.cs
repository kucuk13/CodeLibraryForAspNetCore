using System.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text;
using MiddlewareExample.Extensions;

namespace MiddlewareExample.Middlewares
{
    public class MainMiddleware
    {
        RequestDelegate _next;
        private static readonly string UnauthorizedMessage = "Bu işlemi yapmaya yetkiniz yoktur.";

        public MainMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var watch = Stopwatch.StartNew();
            var responseMessage = string.Empty;

            if (AuthorizeExtension.IsAuthorize(httpContext))
            {
                var responseStream = new MemoryStream();
                var originalBodyStream = httpContext.Response.Body;
                httpContext.Response.Body = responseStream;

                await _next.Invoke(httpContext);

                responseStream.Seek(0, SeekOrigin.Begin);
                responseMessage = await new StreamReader(responseStream, Encoding.UTF8).ReadToEndAsync();
                responseStream.Seek(0, SeekOrigin.Begin);

                await httpContext.Response.Body.CopyToAsync(originalBodyStream);
            }
            else
            {
                responseMessage = UnauthorizedMessage;
                await ReturnUnAuthorizeMessage(httpContext);
            }

            watch.Stop();
            WriteLogToDatabase(httpContext.Request, responseMessage, watch);
        }

        private void WriteLogToDatabase(HttpRequest httpRequest, string responseMessage, Stopwatch? stopwatch)
        {
            Console.WriteLine(httpRequest.Scheme +
                "://" +
                httpRequest.Host.Value +
                httpRequest.Path.Value +
                " service executed in " +
                stopwatch?.ElapsedMilliseconds + " ms. " +
                "And result is " + responseMessage + ".");
        }

        private void WriteLogToTextFile()
        {
        }

        private async Task ReturnUnAuthorizeMessage(HttpContext context)
        {
            await ReturnErrorResponse(context, HttpStatusCode.Unauthorized, UnauthorizedMessage);
        }

        private async Task ReturnErrorResponse(HttpContext context, HttpStatusCode httpStatusCode, string message)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)httpStatusCode;
            await context.Response.WriteAsync(message);
        }



    }
}
