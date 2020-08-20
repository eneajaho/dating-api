using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatingAPI.Contracts
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> Entity();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<bool> Exists(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}