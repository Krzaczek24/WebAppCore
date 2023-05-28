# Core.WebApi
Template for WebApi application
## v1.2.0
* Added exceptions
* Common failure response model
* Middleware from now is handling exceptions and allows methods overriding
* All endpoints are returning `ErrorResponse` for failures by default 
## v1.1.0
* Removed unnecessary dependency to `Core.Database.EntityFrameworkCore`
* `AddScopedDbServices(this IServiceCollection services)` no longer available
## v1.0.0
* `ProducesResponseAttribute` - nicer version for `ProducesResponseTypeAttribute`
* `LoggingMiddleware` - allows to log exceptions for every request and response
* `HttpContextExtension`
	* `SetGuid`/`GetGuid` - for setting and getting `Guid` from `context.Features`
	* `GetPath` - which returns request path nicely
* `AddScopedDbServices(this IServiceCollection services)`
* `BaseController` with:
	* `NLog.ILogger`
	* `AutoMapper.IMapper`
