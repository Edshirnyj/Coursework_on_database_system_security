using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using fullstack_mini_project.Models;
using fullstack_mini_project.Services;

namespace fullstack_mini_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public AdminController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet("{tableName}")]
        public async Task<ActionResult<IEnumerable<DatabaseModel>>> GetAll(string tableName)
        {
            var data = await _databaseService.GetAllAsync(tableName);
            return Ok(data);
        }

        [HttpPost("{tableName}")]
        public async Task<ActionResult> Create(string tableName, [FromBody] DatabaseModel model)
        {
            await _databaseService.CreateAsync(tableName, model);
            return CreatedAtAction(nameof(GetAll), new { tableName }, model);
        }

        [HttpPut("{tableName}/{id}")]
        public async Task<ActionResult> Update(string tableName, int id, [FromBody] DatabaseModel model)
        {
            await _databaseService.UpdateAsync(tableName, id, model);
            return NoContent();
        }

        [HttpDelete("{tableName}/{id}")]
        public async Task<ActionResult> Delete(string tableName, int id)
        {
            await _databaseService.DeleteAsync(tableName, id);
            return NoContent();
        }
    }
}