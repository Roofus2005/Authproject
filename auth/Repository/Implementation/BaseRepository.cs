using auth.Context;
using auth.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace auth.Repository.Implementation
{
    public class BaseRepository<T> where T : BaseEnity
    {
        protected AuthContext _context;
        public async Task<T> CheckAsync(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().
                FirstOrDefaultAsync(exp);
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
