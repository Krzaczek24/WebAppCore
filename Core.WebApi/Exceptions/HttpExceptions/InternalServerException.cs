using Core.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

namespace Core.WebApi.Exceptions.HttpExceptions
{
    public class InternalServerException : HttpException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public InternalServerException() { }

        public InternalServerException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }

    public class InternalServerException<T> : HttpException<T> where T : IError
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public InternalServerException(T error, Exception? innerException = null)
            : base(error, innerException) { }

        public InternalServerException(IEnumerable<T> errors, Exception? innerException = null)
            : base(errors, innerException) { }
    }
}
