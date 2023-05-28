using Core.WebApi.Models;
using System;
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

    public sealed class BadRequestErrorException : HttpErrorException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public BadRequestErrorException(ErrorModel error, Exception? innerException = null)
            : base(error, innerException) { }
    }
}
