using Microsoft.AspNetCore.Mvc;
using AspNetApp.Data;
using AspNetApp.Models.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminDbContext _context;

        public AdminController(AdminDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminModel>>> GetAdmins()
        {
            return await _context.Admins.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminModel>> GetAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        [HttpPost]
        public async Task<ActionResult<AdminModel>> PostAdmin(AdminModel admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdmin), new { id = admin.Id }, admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, AdminModel admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.Id == id);
        }
    }
}