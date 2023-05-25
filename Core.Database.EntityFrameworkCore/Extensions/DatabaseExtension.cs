using Core.Database.Models;
using Core.Database.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Core.Database.Extensions
{
    public static class DatabaseExtension
    {
        public static IUpdateBuilder<TEntity> Update<TEntity>(this DbContext database, int id)
            where TEntity : class, IDbTableCommonModel, new()
        {
            return new UpdateBuilder<DbContext, TEntity>(database, id);
        }

        public static async Task<int> Remove<TEntity>(this DbContext database, int id)
            where TEntity : class, IDbTableCommonModel, new()
        {
            try
            {
                var entity = new TEntity() { Id = id };
                database.Attach(entity);
                database.Remove(entity);
                return await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) { }

            return 0;
        }

        public static string GetInnerExceptionMessage(this Exception ex) => ex.InnerException?.Message ?? ex.Message;
        public static bool IsDuplicateEntryException(this DbUpdateException ex) => ex.InnerException?.Message?.StartsWith("Duplicate entry") ?? false;
        public static bool IsCannotDeleteOrUpdateExcpetion(this DbUpdateException ex) => ex.InnerException?.Message?.StartsWith("Cannot delete or update") ?? false;

    }
}
