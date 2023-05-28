using Core.WebApi.Models;
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

    public sealed class UnauthorizedErrorException : HttpErrorException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        public UnauthorizedErrorException(ErrorModel error, Exception? innerException = null)
            : base(error, innerException) { }
    }
}
