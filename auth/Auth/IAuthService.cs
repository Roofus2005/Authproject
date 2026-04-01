using auth.Dtos;

namespace auth.Auth
{
    public interface IAuthService
    {
        string GenerateToken(UserDto userDto);
    }
}
