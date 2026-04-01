using auth.Entity;
using System.Linq.Expressions;

namespace auth.Repository.Interface
{
    public interface IRegisterRepository : IBaseRepository<Register>
    {
        Task<Register?> GetAsync(Guid id);
        Task<Register?> GetAsync(Expression<Func<Register, bool>> exp);
    }
}
