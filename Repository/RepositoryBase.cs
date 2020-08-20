using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DatingAPI.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public BaseRepository(DbContext repositoryContext)
        {
            Context = repositoryContext.Set<T>();
        }

        private DbSet<T> Context { get; }

        public IQueryable<T> Entity()
        {
            return Context.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Context.Where(expression).AsNoTracking();
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return await Context.AnyAsync(expression);
        }

        public void Create(T entity)
        {
            Context.Add(entity);
        }

        public void Update(T entity)
        {
            Context.Update(entity);
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
        }
    }
}