using Core.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.WebApi.Exceptions
{
    public abstract class HttpErrorException<T> : HttpException where T : IError
    {
        public ICollection<T> Errors { get; } = Array.Empty<T>();

        public HttpErrorException(Exception? innerException = null) { }

        public HttpErrorException(T error, Exception? innerException = null)
            : base(error.Message, innerException)
        {
            Errors = new[] { error }.ToList();
        }

        public HttpErrorException(IEnumerable<T> errors, Exception? innerException = null, string message = "")
            : base(message ?? errors.FirstOrDefault()?.Message ?? string.Empty, innerException)
        {
            Errors = errors.ToList();
        }
    }
}
