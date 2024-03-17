using Core.Database.Models;
using Core.Database.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Database.Extensions
{
    public static class DatabaseExtension
    {
        public static async Task<bool> Exists<TEntity>(this IQueryable<TEntity> set, int id)
            where TEntity : class, IDbTableCommonModel, new()
        {
            return await set.AnyAsync(x => x.Id == id);
        }

        public static IUpdateBuilder<TEntity> UpdateBuilder<TEntity>(this DbContext database, int id)
            where TEntity : class, IDbTableCommonModel, new()
        {
            return new UpdateBuilder<DbContext, TEntity>(database, id);
        }

        public static void Delete<TEntity>(this DbContext database, int id)
            where TEntity : class, IDbTableCommonModel, new()
        {
            try
            {
                var entity = new TEntity() { Id = id };
                database.Attach(entity);
                database.Remove(entity);
            }
            catch (DbUpdateConcurrencyException) { }
        }

        public static string GetInnerExceptionMessage(this Exception ex) => ex.InnerException?.Message ?? ex.Message;
        public static bool IsDuplicateEntryException(this DbUpdateException ex) => ex.InnerException?.Message?.StartsWith("Duplicate entry") ?? false;
        public static bool IsCannotDeleteOrUpdateException(this DbUpdateException ex) => ex.InnerException?.Message?.StartsWith("Cannot delete or update") ?? false;

    }
}
