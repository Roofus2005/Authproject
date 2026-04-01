using auth.Entity;
using auth.Repository.Implementation;
using auth.Repository.Interface;
using auth.Service.Interface;

namespace auth.Service.Implementation
{
    public class RoleService : IRoleService
    {
        IRoleRepository _repository;
        IUnitOfWork _unitOfWork;
        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _repository = roleRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateRole(string roleName)
        {
            if (roleName == null)
            {
                return false;
            }

            var role = new Role
            {
                RoleName = roleName,
            };

            await _repository.CreateAsync(role);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
