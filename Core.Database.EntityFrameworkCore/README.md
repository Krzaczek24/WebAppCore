# Core.Database.EntityFrameworkCore
Template for database library
## v1.2.1
* Removed invalid method `IsActive()`
## v1.2.0
* Upgraded to .NET8.0 version
* Changed reference from project to nuget package
## v1.1.0
* ServiceCollectionExtensions moved to Core.WebApi
## v1.0.3
* Reverted `v1.0.2` changes, simplified generic methods by replacing `TDbContext` with `DbContext`
## v1.0.2
* Renamed `Update` to `UpdateBuilder` and `Remove` to `Delete` to avoid ambiguous method calls
## v1.0.1
* Fixed few access modifiers
## v1.0.0
* `IDbTableCommonModel` - interface for base model, containing `Id` property and `SetModifLogin`, `SetModifDate`, `IsActive` methods
* `IDbService` & `DbService<TDbContext>` - template for database services
* `UpdateBuilder` - allowing update single field of object (single column of entity), also sets `ModifLogin` and `ModifDate`
* Query extensions:
	* `ActiveWhere` - checks `IsActive` flag
	* `Update` - converts query to `UpdateBuilder`
	* `Remove` - allows to remove single record by `Id`
* Checks for exceptions:
	* `bool IsDuplicateEntryException(this DbUpdateException ex)`
	* `bool IsCannotDeleteOrUpdateExcpetion(this DbUpdateException ex)`
* `AddScopedDbServices(this IServiceCollection services)` - extension for WebApi `IServiceCollection services`
