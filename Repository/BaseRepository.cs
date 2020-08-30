using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DatingAPI.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private DbSet<T> Entity { get; }

        protected BaseRepository(DbContext repoContext)
        {
            Entity = repoContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Entity;
        }

        public Task<List<T>> GetAllAsync()
        {
            return Entity.ToListAsync();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return Entity.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return Entity.Where(expression);
        }

        public Task<int> CountAll()
        {
            return Entity.CountAsync();
        }

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return Entity.CountAsync(predicate);
        }

        public Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return Entity.AnyAsync(expression);
        }

        public void Create(T entity)
        {
            Entity.Add(entity);
        }

        public void Update(T entity)
        {
            Entity.Update(entity);
        }

        public void Delete(T entity)
        {
            Entity.Remove(entity);
        }
    }
}