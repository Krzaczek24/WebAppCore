using Core.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

namespace Core.WebApi.Exceptions.HttpExceptions
{
    public class ForbiddenException : HttpException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;

        public ForbiddenException() { }

        public ForbiddenException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }

    public class ForbiddenException<T> : HttpException<T> where T : IError
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;

        public ForbiddenException(T error, Exception? innerException = null)
            : base(error, innerException) { }

        public ForbiddenException(IEnumerable<T> errors, Exception? innerException = null)
            : base(errors, innerException) { }
    }
}
