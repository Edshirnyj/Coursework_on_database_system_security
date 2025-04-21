using Microsoft.AspNetCore.Mvc;

namespace fullstack_aspnet_postgresql.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome to the Home Page!");
        }
    }
}