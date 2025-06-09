using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<UserController> _logger;
        private readonly JwtService _jwtService;

        public AuthController(UserManager<IdentityUser> userManager, ILogger<UserController> logger, JwtService jwtService)
        {
            _userManager = userManager;
            _logger = logger;
            _jwtService = jwtService;
        }

        public class AuthModelView
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }

        [HttpPost("LoginSync")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginSync([FromBody] AuthModelView dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                var token = _jwtService.GenerateToken(user);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}