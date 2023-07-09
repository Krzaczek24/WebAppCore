using Core.WebApi.Exceptions;
using Core.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.WebApi.Middlewares
{
    public static class RestLoggingMiddlewareHelper
    {
        public static IApplicationBuilder UseRestLoggingMiddleware(this IApplicationBuilder app) => app.UseMiddleware<LoggingMiddleware>();
    }

    public class LoggingMiddleware
    {
        protected static ILogger Logger { get; } = LogManager.GetLogger(nameof(LoggingMiddleware));

        private RequestDelegate Next { get; }

        public LoggingMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await HandleRequest(httpContext);
            await HandleResponse(httpContext);
        }

        protected virtual async Task HandleRequest(HttpContext httpContext)
        {
            httpContext.PassRequestId();

            var request = httpContext.Request;
            string bodyText = string.Empty;

            request.EnableBuffering();

            using (var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyText = await reader.ReadToEndAsync();
                request.Body.Position = 0;
            }

            LogRequest(httpContext, bodyText);
        }

        protected virtual async Task HandleResponse(HttpContext httpContext)
        {
            var originalBodyStream = httpContext.Response.Body;
            var responseBody = new MemoryStream();

            httpContext.Response.Body = responseBody;

            try
            {
                await Next(httpContext);
            }
            catch (HttpException exception)
            {
                httpContext.Response.StatusCode = (int)exception.StatusCode;
                await HandleException(httpContext, exception);
            }
            catch (Exception exception)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await HandleException(httpContext, exception);
            }

            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            string bodyText = await new StreamReader(httpContext.Response.Body).ReadToEndAsync();
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

            LogResponse(httpContext, bodyText);

            await responseBody.CopyToAsync(originalBodyStream);
        }

        protected virtual async Task HandleException(HttpContext httpContext, Exception exception)
        {
            LogException(httpContext, exception);

            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(GetErrorResponse(exception)));
        }

        protected virtual void LogRequest(HttpContext httpContext, string bodyText)
        {
            Logger.Info($"REQUEST  ({httpContext.GetRequestId()}) | PATH ({httpContext.Request.GetPath()}) | BODY ({bodyText})");
        }

        protected virtual void LogResponse(HttpContext httpContext, string bodyText)
        {
            Logger.Info($"RESPONSE ({httpContext.GetRequestId()}) | CODE ({httpContext.Response.StatusCode}) | BODY ({bodyText})");
        }

        protected virtual void LogException(HttpContext httpContext, Exception exception)
        {
            if (httpContext.Response.StatusCode >= (int)HttpStatusCode.InternalServerError)
            {
                Logger.Error(exception, exception.Message);
            }
        }

        protected virtual object GetErrorResponse(Exception exception) => exception.Message;
    }
}
