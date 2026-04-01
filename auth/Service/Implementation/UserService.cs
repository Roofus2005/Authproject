using auth.Dtos;
using auth.Repository.Interface;
using auth.Service.Interface;

namespace auth.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BaseResponse<UserDto?>> LoginAsync(LoginRequestModel model)
        {
            try
            {
                var user = await _userRepository.GetAsync(x => x.Email == model.Email);
                if (user == null)
                {
                    return new BaseResponse<UserDto?>
                    {
                        Message = "Email does not exist",
                        Status = false
                    };
                }

                if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                {
                    return new BaseResponse<UserDto?>
                    {
                        Message = "Invalid Credentials",
                        Status = false
                    };
                }
                return new BaseResponse<UserDto?>
                {
                    Message = "Login successful",
                    Status = true,
                    Data = new UserDto
                    {
                        Id = user.Id,
                        Email = user.Email,
                        UserName = user.UserName,
                        UserRoles = user.UserRoles
                    }
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserDto?>
                {
                    Message = "An error occurred while logging in",
                    Status = false
                };
            }
        }
    }
}
