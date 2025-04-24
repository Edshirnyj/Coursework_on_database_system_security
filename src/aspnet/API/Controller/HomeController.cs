using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome to the ASP.NET Core and React application!");
        }        
    }
}