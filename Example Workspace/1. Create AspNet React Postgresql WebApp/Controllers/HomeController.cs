using Microsoft.AspNetCore.Mvc;

namespace aspnet_react_postgresql_app.Controllers
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