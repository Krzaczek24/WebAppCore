using Core.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

namespace Core.WebApi.Exceptions.HttpExceptions
{
    public class BadRequestException : HttpException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public BadRequestException() { }

        public BadRequestException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }

    public class BadRequestException<T> : HttpException<T> where T : IError
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public BadRequestException(T error, Exception? innerException = null)
            : base(error, innerException) { }

        public BadRequestException(IEnumerable<T> errors, Exception? innerException = null)
            : base(errors, innerException) { }
    }
}
