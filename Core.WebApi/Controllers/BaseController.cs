using AutoMapper;
using Core.WebApi.Attributes;
using Core.WebApi.Responses;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Net;

namespace Core.WebApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected ILogger Logger { get; }
        protected IMapper Mapper { get; }

        public BaseController(IMapper mapper)
        {
            Logger = LogManager.GetLogger(GetType().UnderlyingSystemType.FullName);
            Mapper = mapper;
        }
    }

    [ProducesResponse<ErrorResponse>(HttpStatusCode.BadRequest)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.Unauthorized)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.Forbidden)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.NotFound)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.Conflict)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.InternalServerError)]
    public abstract class BaseResponseController : BaseController
    {
        public BaseResponseController(IMapper mapper) : base(mapper) { }
    }
}
