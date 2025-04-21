using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YourNamespace.Data; // Adjust the namespace as necessary
using YourNamespace.Models; // Adjust the namespace as necessary
using YourNamespace.Services; // Adjust the namespace as necessary

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.PasswordHash))
            {
                return BadRequest("Invalid user data.");
            }

            var result = await _authService.RegisterUserAsync(user);
            if (result)
            {
                return Ok("User registered successfully.");
            }

            return BadRequest("User registration failed.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.PasswordHash))
            {
                return BadRequest("Invalid login data.");
            }

            var token = await _authService.LoginUserAsync(user);
            if (token != null)
            {
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username or password.");
        }
    }
}