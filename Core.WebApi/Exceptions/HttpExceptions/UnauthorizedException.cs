using Core.WebApi.Interfaces;
using System;
using System.Collections.Generic;
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

    public class UnauthorizedException<T> : HttpException<T> where T : IError
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        public UnauthorizedException(T error, Exception? innerException = null)
            : base(error, innerException) { }

        public UnauthorizedException(IEnumerable<T> errors, Exception? innerException = null)
            : base(errors, innerException) { }
    }
}
