using Core.WebApi.Interfaces;
using System;
using System.Collections.Generic;

namespace Core.WebApi.Responses
{
    public class ErrorResponse<T> where T : IError
    {
        public ICollection<T> Errors { get; set; } = Array.Empty<T>();

        public ErrorResponse() { }

        public ErrorResponse(T error) : this(new[] { error }) { }

        public ErrorResponse(ICollection<T> errors)
        {
            Errors = errors;
        }
    }
}
