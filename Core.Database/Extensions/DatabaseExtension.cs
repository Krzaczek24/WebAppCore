using Core.Database.Models;
using Core.Database.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Core.Database.Extensions
{
    internal static class DatabaseExtension
    {
        public static IUpdateBuilder<TEntity> Update<TDbContext, TEntity>(this TDbContext database, int id)
            where TDbContext : DbContext
            where TEntity : class, IDbTableCommonModel, new()
        {
            return new UpdateBuilder<TDbContext, TEntity>(database, id);
        }

        public static async Task<int> Remove<TDbContext, TEntity>(this TDbContext database, int id)
            where TDbContext : DbContext
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
