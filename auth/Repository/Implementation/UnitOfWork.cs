using auth.Context;
using auth.Repository.Interface;

namespace auth.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthContext _authContext;
        public UnitOfWork (AuthContext authContext)
        {
            _authContext = authContext;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _authContext.SaveChangesAsync();
        }
    }
}
