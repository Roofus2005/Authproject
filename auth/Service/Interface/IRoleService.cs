namespace auth.Service.Interface
{
    public interface IRoleService
    {
        Task<bool> CreateRole(string roleName);
    }
}
