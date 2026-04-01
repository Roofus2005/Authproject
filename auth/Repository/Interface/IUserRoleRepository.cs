using auth.Entity;

namespace auth.Repository.Interface
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>
    {
        Task<UserRole> GetByUserAndRoleIdAsync(Guid userId, Guid roleId);
        Task<ICollection<UserRole>> GetRolesByUserIdAsync(Guid userId);
    }
}
