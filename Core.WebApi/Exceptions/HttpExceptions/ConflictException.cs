using Core.WebApi.Models;
using System;
using System.Net;

namespace Core.WebApi.Exceptions.HttpExceptions
{
    public class ConflictException : HttpException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public ConflictException() { }

        public ConflictException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }

    public sealed class ConflictErrorException : HttpErrorException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public ConflictErrorException(ErrorModel error, Exception? innerException = null)
            : base(error, innerException) { }
    }
}
