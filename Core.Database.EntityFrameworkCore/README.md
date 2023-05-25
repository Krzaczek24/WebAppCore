# Core.Database.EntityFrameworkCore
Template for database library
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
