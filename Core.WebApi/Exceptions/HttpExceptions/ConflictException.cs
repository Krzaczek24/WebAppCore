using Core.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

namespace Core.WebApi.Exceptions.HttpExceptions
{
    public class ConflictException : HttpException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public ConflictException() { }

        public ConflictException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }

    public class ConflictException<T> : HttpException<T> where T : IError
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public ConflictException(T error, Exception? innerException = null)
            : base(error, innerException) { }

        public ConflictException(IEnumerable<T> errors, Exception? innerException = null)
            : base(errors, innerException) { }
    }
}
