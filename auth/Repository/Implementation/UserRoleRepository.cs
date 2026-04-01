using auth.Context;
using auth.Entity;
using auth.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace auth.Repository.Implementation
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AuthContext authContext)
        {
            _context = authContext;
        }
        public async Task<UserRole> GetByUserAndRoleIdAsync(Guid userId, Guid roleId)
        {
            return await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        }

        public async Task<ICollection<UserRole>> GetRolesByUserIdAsync(Guid userId)
        {
            return await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Include(ur => ur.Role) // Load the related Role
                .ToListAsync();
        }
    }
}
