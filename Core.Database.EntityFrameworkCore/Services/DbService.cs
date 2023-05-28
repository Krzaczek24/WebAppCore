using AutoMapper;
using Core.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Database.Services
{
    public abstract class DbService<TDbContext> : ICoreService
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
