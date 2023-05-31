using Core.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

namespace Core.WebApi.Exceptions.HttpErrorExceptions
{
    public class InternalServerException<T> : HttpErrorException<T> where T : IError
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public InternalServerException(T error, Exception? innerException = null)
            : base(error, innerException) { }

        public InternalServerException(IEnumerable<T> errors, Exception? innerException = null, string message = "")
            : base(errors, innerException, message) { }
    }
}
