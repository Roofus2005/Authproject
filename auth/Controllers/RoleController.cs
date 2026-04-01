using auth.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromBody] string model)
        {
            _logger.LogInformation("POST /api/role/create called at {Time}", DateTime.UtcNow);

            if (string.IsNullOrWhiteSpace(model))
                return BadRequest(new { Message = "Role name is required." });

            var result = await _roleService.CreateRole(model);

            if (!result)
                return BadRequest(new { Message = "Failed to create role." });

            return Ok(new { Message = "Role created successfully." });
        }
    }
}
