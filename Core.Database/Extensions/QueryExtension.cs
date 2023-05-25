using Core.Database.Models;
using System.Linq.Expressions;
using System.Linq;
using System;

namespace Core.Database.Extensions
{
    public static class QueryExtension
    {
        public static IQueryable<T> ActiveWhere<T>(this IQueryable<T> query) where T : IDbTableCommonModel
        {
            return query.Where(x => x.IsActive());
        }

        public static IQueryable<T> ActiveWhere<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate) where T : IDbTableCommonModel
        {
            return ActiveWhere(query).Where(predicate);
        }
    }
}
