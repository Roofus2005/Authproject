using auth.Context;
using auth.Entity;
using auth.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace auth.Repository.Implementation
{
    public class RegisterRepository : BaseRepository<Register>, IRegisterRepository
    {

        public RegisterRepository(AuthContext authContext) 
        {
            _context = authContext;
        }
        public async Task<Register?> GetAsync(Guid id)
        {
            return await _context.Set<Register>()
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
        }

        public async Task<Register?> GetAsync(Expression<Func<Register, bool>> exp)
        {
            return await _context.Set<Register>()
                .AsNoTracking()
                .FirstOrDefaultAsync(exp);
        }
    }
}
