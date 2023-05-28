using Core.WebApi.Models;
using System;
using System.Net;

namespace Core.WebApi.Exceptions.HttpExceptions
{
    public class InternalServerException : HttpException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public InternalServerException() { }

        public InternalServerException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }

    public sealed class InternalServerErrorException : HttpErrorException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public InternalServerErrorException(ErrorModel error, Exception? innerException = null)
            : base(error, innerException) { }
    }
}
