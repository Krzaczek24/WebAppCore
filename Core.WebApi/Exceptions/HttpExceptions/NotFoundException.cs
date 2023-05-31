using Core.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

namespace Core.WebApi.Exceptions.HttpExceptions
{
    public class NotFoundException : HttpException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public NotFoundException() { }

        public NotFoundException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }

    public class NotFoundException<T> : HttpException<T> where T : IError
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public NotFoundException(T error, Exception? innerException = null)
            : base(error, innerException) { }

        public NotFoundException(IEnumerable<T> errors, Exception? innerException = null)
            : base(errors, innerException) { }
    }
}
