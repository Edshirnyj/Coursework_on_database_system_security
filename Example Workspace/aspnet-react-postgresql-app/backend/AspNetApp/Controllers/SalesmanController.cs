using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetApp.Data;
using AspNetApp.Models.Salesman;

namespace AspNetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesmanController : ControllerBase
    {
        private readonly SalesmanDbContext _context;

        public SalesmanController(SalesmanDbContext context)
        {
            _context = context;
        }

        // GET: api/salesman
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesmanModel>>> GetSalesmen()
        {
            return await _context.Salesmen.ToListAsync();
        }

        // GET: api/salesman/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesmanModel>> GetSalesman(int id)
        {
            var salesman = await _context.Salesmen.FindAsync(id);

            if (salesman == null)
            {
                return NotFound();
            }

            return salesman;
        }

        // POST: api/salesman
        [HttpPost]
        public async Task<ActionResult<SalesmanModel>> PostSalesman(SalesmanModel salesman)
        {
            _context.Salesmen.Add(salesman);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesman", new { id = salesman.Id }, salesman);
        }

        // PUT: api/salesman/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesman(int id, SalesmanModel salesman)
        {
            if (id != salesman.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesmanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/salesman/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesman(int id)
        {
            var salesman = await _context.Salesmen.FindAsync(id);
            if (salesman == null)
            {
                return NotFound();
            }

            _context.Salesmen.Remove(salesman);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesmanExists(int id)
        {
            return _context.Salesmen.Any(e => e.Id == id);
        }
    }
}