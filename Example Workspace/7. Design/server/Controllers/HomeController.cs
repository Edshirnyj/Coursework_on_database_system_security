using Microsoft.AspNetCore.Mvc;

namespace fullstack_mini_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to the Fullstack Mini Project!");
        }
    }
}