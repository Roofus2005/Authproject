using auth.Entity;
using System.Linq.Expressions;

namespace auth.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetAsync(Guid id);
        Task<User?> GetAsync(Expression<Func<User, bool>> exp);
        Task<User?> GetEmailAsync(string email);
    }
}
