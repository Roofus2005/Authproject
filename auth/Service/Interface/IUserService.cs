using auth.Dtos;

namespace auth.Service.Interface
{
    public interface IUserService
    {
        Task<BaseResponse<UserDto?>> LoginAsync(LoginRequestModel model);
    }
}
