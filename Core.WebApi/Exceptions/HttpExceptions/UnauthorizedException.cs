using System;
using System.Net;

namespace Core.WebApi.Exceptions.HttpExceptions
{
    public class UnauthorizedException : HttpException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        public UnauthorizedException() { }

        public UnauthorizedException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }
}
