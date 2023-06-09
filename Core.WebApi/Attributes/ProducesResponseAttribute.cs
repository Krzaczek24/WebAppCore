﻿using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Core.WebApi.Attributes
{
    public class ProducesResponseAttribute : ProducesResponseTypeAttribute
    {
        public ProducesResponseAttribute(HttpStatusCode httpStatus) : base((int)httpStatus) { }
    }

    public class ProducesResponseAttribute<TResponse> : ProducesResponseTypeAttribute
    {
        public ProducesResponseAttribute(HttpStatusCode httpStatus) : base(typeof(TResponse), (int)httpStatus) { }
    }
}
