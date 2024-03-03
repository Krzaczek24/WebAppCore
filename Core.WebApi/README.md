# Core.WebApi
Template for WebApi application
## v1.5.0
* Upgraded to .NET8.0 version
* `AddCoreSingletonServices` extension added
* Fixed exception message for `AddCore*Services` when implementation and interface names mismatch occurs
## v1.4.5
* Extended `HttpContextExtension` with `GetClientIp()` method
## v1.4.4
* Added `HttpRequestExtension` with `GetId()` and `GetPath()` methods
* Extended `HttpContextExtension` with `PassRequestId()` method
* Moved passing RequestId from `LoggingMiddleware.Invoke` to `LoggingMiddleware.HandleRequest`
## v1.4.3
* Added nongeneric `ProducesResponseAttribute`
## v1.4.2
* Added parameterless constructors for exceptions
## v1.4.1
* Exceptions placed in separated namespaces
## v1.4.0
* Removed returning `ErrorResponse` by default
* Removed common failure response model
* Added `IError` interface
* Added virtual method `GetErrorResponse` to `LoggingMiddleware`
## v1.3.0
* ServiceCollectionExtensions moved from Core.Database.EntityFrameworkCore
* Code cleanup
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
