using auth.Entity;

namespace auth.Repository.Interface
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> GetRoleAsync(string roleName);
    }
}
