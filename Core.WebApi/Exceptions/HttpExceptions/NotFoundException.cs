using Core.WebApi.Models;
using System;
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

    public sealed class NotFoundErrorException : HttpErrorException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public NotFoundErrorException(ErrorModel error, Exception? innerException = null)
            : base(error, innerException) { }
    }
}
