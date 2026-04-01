using auth.Auth;
using auth.Dtos;
using auth.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var result = await _userService.LoginAsync(model);
            if (result.Status)
            {
                string token = _authService.GenerateToken(result.Data!);
                return Ok(new { Token = token });

            }
            return Unauthorized(result);
        }
    }
}
