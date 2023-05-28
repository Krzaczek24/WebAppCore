using Core.WebApi.Models;
using System;
using System.Net;

namespace Core.WebApi.Exceptions
{
    public abstract class HttpException : Exception
    {
        internal abstract HttpStatusCode StatusCode { get; }

        public HttpException() { }

        public HttpException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }

    public abstract class HttpErrorException : HttpException
    {
        internal ErrorModel Error { get; }

        public HttpErrorException(ErrorModel error, Exception? innerException = null)
            : base(error.Message, innerException)
        {
            Error = error;
        }
    }
}
