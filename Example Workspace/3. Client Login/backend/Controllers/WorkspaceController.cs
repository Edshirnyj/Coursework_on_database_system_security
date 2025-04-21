using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace.Data; // Update with your actual namespace
using YourNamespace.Models; // Update with your actual namespace
using YourNamespace.Services; // Update with your actual namespace

namespace YourNamespace.Controllers // Update with your actual namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkspaceController : ControllerBase
    {
        private readonly WorkspaceService _workspaceService;

        public WorkspaceController(WorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Workspace>> CreateWorkspace([FromBody] Workspace workspace)
        {
            if (workspace == null)
            {
                return BadRequest("Workspace cannot be null.");
            }

            var createdWorkspace = await _workspaceService.CreateWorkspaceAsync(workspace);
            return CreatedAtAction(nameof(GetWorkspaces), new { id = createdWorkspace.Id }, createdWorkspace);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workspace>>> GetWorkspaces()
        {
            var workspaces = await _workspaceService.GetWorkspacesAsync();
            return Ok(workspaces);
        }
    }
}