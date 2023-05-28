using Core.WebApi.Models;
using System;
using System.Collections.Generic;

namespace Core.WebApi.Responses
{
    public class ErrorResponse<T>
    {
        public ICollection<T> Errors { get; } = Array.Empty<T>();

        public ErrorResponse() { }

        public ErrorResponse(T error) : this(new[] { error }) { }

        public ErrorResponse(ICollection<T> errors)
        {
            Errors = errors;
        }
    }

    public class ErrorResponse : ErrorResponse<ErrorModel>
    {
        public ErrorResponse() { }

        public ErrorResponse(ErrorModel error) : base(error) { }

        public ErrorResponse(ICollection<ErrorModel> errors) : base(errors) { }
    }
}
