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
}
