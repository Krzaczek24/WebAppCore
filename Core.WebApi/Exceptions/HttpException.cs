using Core.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public abstract class HttpException<T> : HttpException where T : IError
    {
        public List<T> Errors { get; }

        public HttpException(T error, Exception? innerException = null)
            : base(error.Message, innerException)
        {
            Errors = new[] { error }.ToList();
        }

        public HttpException(IEnumerable<T> errors, Exception? innerException = null)
            : base(errors.FirstOrDefault()?.Message ?? string.Empty, innerException)
        {
            Errors = errors.ToList();
        }
    }
}
