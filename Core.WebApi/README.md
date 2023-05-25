# Core.WebApi
Template for WebApi application

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
