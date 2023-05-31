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
}
