using auth.Context;
using auth.Entity;
using auth.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace auth.Repository.Implementation
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(AuthContext authContext) 
        {
            _context = authContext;
        }
        public async Task<Role?> GetRoleAsync(string roleName)
        {
            
                return await _context.Set<Role>()
                   .Include(x => x.UserRoles)
                   .FirstOrDefaultAsync(r => r.RoleName.ToLower() == roleName.ToLower());
        }
    }
}
