using auth.Dtos;

namespace auth.Service.Interface
{
    public interface IRegisterService
    {
        Task<BaseResponse<RegisterDto?>> CreateAsync(CreateRegisterModel model);
    }
}
