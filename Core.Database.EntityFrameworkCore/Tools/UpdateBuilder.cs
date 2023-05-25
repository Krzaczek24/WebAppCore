using Core.Database.Models;
using KrzaqTools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Core.Database.Tools
{
    public interface IUpdateBuilder<TEntity> where TEntity : class, IDbTableCommonModel, new()
    {
        public IUpdateBuilder<TEntity> Set<TProperty>(Expression<Func<TEntity, TProperty>> selector, TProperty value);
        public IUpdateBuilder<TEntity> Set<TProperty>(Expression<Func<TEntity, TProperty>> selector, Specifiable<TProperty> value);
        public IUpdateBuilder<TEntity> SetIfNotNullOrDefault<TProperty>(Expression<Func<TEntity, TProperty>> selector, TProperty value);
        public Task<int> Execute(string updaterLogin);
    }

    public class UpdateBuilder<TDbContext, TEntity> : IUpdateBuilder<TEntity>
        where TDbContext : DbContext
        where TEntity : class, IDbTableCommonModel, new()
    {
        private TDbContext context;
        private TEntity entity;
        public bool AnyChanges { get; private set; } = false;

        public UpdateBuilder(TDbContext database, int id)
        {
            context = database;
            entity = new TEntity() { Id = id };
            try { context.Attach(entity); } catch { }
        }

        public IUpdateBuilder<TEntity> Set<TProperty>(Expression<Func<TEntity, TProperty>> selector, TProperty value)
        {
            var property = (PropertyInfo)((MemberExpression)selector.Body).Member;
            property.SetValue(entity, value);
            context.Entry(entity).Property(selector).IsModified = true;
            AnyChanges = true;
            return this;
        }

        public IUpdateBuilder<TEntity> Set<TProperty>(Expression<Func<TEntity, TProperty>> selector, Specifiable<TProperty> value)
        {
            return value.IsSpecified ? Set(selector!, value.Value) : this;            
        }

        public IUpdateBuilder<TEntity> SetIfNotNullOrDefault<TProperty>(Expression<Func<TEntity, TProperty>> selector, TProperty value)
        {
            return (value == null || value.Equals(default(TProperty))) ? this : Set(selector, value);
        }

        public async Task<int> Execute(string updaterLogin)
        {
            if (AnyChanges)
            {
                entity.SetModifLogin(updaterLogin);
                entity.SetModifDate(DateTime.Now);
                return await context.SaveChangesAsync();
            }

            return default;
        }
    }
}
