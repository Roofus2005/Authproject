using auth.Context;
using auth.Entity;
using auth.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace auth.Repository.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AuthContext authContext)
        {
            _context = authContext;
        }
        public async Task<User?> GetAsync(Guid id)
        {
            return await _context.Set<User>()
                .Include(a => a.UserRoles)
                .ThenInclude(a => a.Role)
                .FirstOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);
        }

        public async Task<User?> GetAsync(Expression<Func<User, bool>> exp)
        {
            return await _context.Set<User>()
                 .Include(a => a.UserRoles)
                 .ThenInclude(a => a.Role)
                 .FirstOrDefaultAsync(exp);
        }

        public async Task<User?> GetEmailAsync(string email)
        {
            return await _context.Set<User>()
                .Include(a => a.UserRoles)
                .ThenInclude(a => a.Role)
                .FirstOrDefaultAsync(a => a.Email == email && a.IsDeleted == false);
        }
    }
}
