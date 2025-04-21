using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;
using System.Threading.Tasks;

namespace fullstack_mini_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string _connectionString;

        public AuthController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE username = @username AND password = @password", connection);
                command.Parameters.AddWithValue("username", userLogin.Username);
                command.Parameters.AddWithValue("password", userLogin.Password);

                var result = (long)await command.ExecuteScalarAsync();

                if (result > 0)
                {
                    return Ok("Congratulations!");
                }
                else
                {
                    return Unauthorized("Error!");
                }
            }
        }
    }

    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}