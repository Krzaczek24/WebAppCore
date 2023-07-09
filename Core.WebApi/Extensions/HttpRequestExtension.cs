using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Core.WebApi.Extensions
{
    public static class HttpRequestExtension
    {
        public static string GetId(this HttpRequest request) => request.Headers["RequestId"].FirstOrDefault(x => !string.IsNullOrEmpty(x)) ?? string.Empty;
        public static string GetPath(this HttpRequest request) => $"{request.Method} {request.Path}{request.QueryString}";
    }
}
