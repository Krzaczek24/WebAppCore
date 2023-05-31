using System;
using System.Net;

namespace Core.WebApi.Exceptions.HttpExceptions
{
    public class ForbiddenException : HttpException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;

        public ForbiddenException() { }

        public ForbiddenException(string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException) { }
    }
}
