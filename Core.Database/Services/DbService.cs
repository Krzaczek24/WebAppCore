using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Core.Database.Services
{
    public interface IDbService { }

    public abstract class DbService<TDbContext> : IDbService
        where TDbContext : DbContext
    {
        protected TDbContext Database { get; }
        protected IMapper Mapper { get; }

        public DbService(TDbContext database, IMapper mapper)
        {
            Database = database;
            Mapper = mapper;
        }
    }
}
