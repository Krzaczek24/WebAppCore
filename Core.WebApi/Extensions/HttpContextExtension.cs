using Microsoft.AspNetCore.Http;
using System;

namespace Core.WebApi.Extensions
{
    public static class HttpContextExtension
    {
        public static string? GetClientIp(this HttpContext context) => context.Connection.RemoteIpAddress?.ToString();

        public static void SetRequestId(this HttpContext context, Guid guid) => context.Features.Set(guid);
        public static Guid GetRequestId(this HttpContext context) => context.Features.Get<Guid>();

        public static void PassRequestId(this HttpContext context)
        {
            context.SetRequestId(Guid.TryParse(context.Request.GetId()!, out Guid guid) ? guid : Guid.NewGuid());
        }
    }
}
