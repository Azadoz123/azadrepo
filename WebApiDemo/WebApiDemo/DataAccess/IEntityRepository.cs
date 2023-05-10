using System.Linq.Expressions;
using WebApiDemo.Entities;

namespace WebApiDemo.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null); // var kullanici = repository.GetAsync(k=>k.Id==15);

        T Get(Expression<Func<T, bool>> predicate = null);
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
   //     Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    //    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
