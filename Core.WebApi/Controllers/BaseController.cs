using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLog;

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
}
