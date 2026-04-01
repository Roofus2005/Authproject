using auth.Dtos;
using auth.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateRegisterModel model)
        {
            if (model == null)
                return BadRequest("Invalid request data.");

            var result = await _registerService.CreateAsync(model);
            if (!result.Status)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
