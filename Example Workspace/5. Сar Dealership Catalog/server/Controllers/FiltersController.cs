using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using car_dealership_catalog.Models;

namespace car_dealership_catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FiltersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Filter>> GetFilters()
        {
            var filters = _context.Filters.ToList();
            return Ok(filters);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFilters(Filter filter)
        {
            if (filter == null)
            {
                return BadRequest();
            }

            _context.Filters.Update(filter);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}