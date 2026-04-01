using System.Linq.Expressions;

namespace auth.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        Task CreateAsync(T entity);
        void Update(T entity);
        Task<T> CheckAsync(Expression<Func<T, bool>> exp);
    }
}
