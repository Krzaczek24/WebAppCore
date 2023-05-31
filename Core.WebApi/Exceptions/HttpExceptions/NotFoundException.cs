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
}
