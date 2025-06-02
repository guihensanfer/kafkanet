using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    [Authorize]    
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<UserController> _logger;

        public UserController(UserManager<IdentityUser> userManager, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public class CreateUserViewModel
        {
            public string UserName { get; set; } = default!;
            public string Email { get; set; } = default!;
            public string Password { get; set; } = default!;
        }


        /// <summary>
        /// Create user using kafka events.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreateUserAsync")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserViewModel dto)
        {
            var user = new IdentityUser()
            {
                UserName = dto.UserName,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("Users.Created");
                return Ok("User was created successfully.");
            }

            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                _logger.LogInformation("Users.Deleted");
                return Ok("User was deleted successfully.");
            }

            return BadRequest(result.Errors);
        }

        /// <summary>
        /// Get user by id immediatelly.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdSync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Ok(new
            {
                user.Id,
                user.UserName,
                user.Email
            });
        }
    }
}