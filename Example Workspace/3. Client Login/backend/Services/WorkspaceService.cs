using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using fullstack_app.Data;
using fullstack_app.Models;

namespace fullstack_app.Services
{
    public class WorkspaceService
    {
        private readonly ClientDbContext _context;

        public WorkspaceService(ClientDbContext context)
        {
            _context = context;
        }

        public async Task<Workspace> CreateWorkspaceAsync(Workspace workspace)
        {
            _context.Workspaces.Add(workspace);
            await _context.SaveChangesAsync();
            return workspace;
        }

        public async Task<List<Workspace>> GetWorkspacesAsync(string ownerId)
        {
            return await _context.Workspaces
                .Where(w => w.OwnerId == ownerId)
                .ToListAsync();
        }

        public async Task<Workspace> GetWorkspaceByIdAsync(int id)
        {
            return await _context.Workspaces.FindAsync(id);
        }

        public async Task<Workspace> UpdateWorkspaceAsync(Workspace workspace)
        {
            _context.Workspaces.Update(workspace);
            await _context.SaveChangesAsync();
            return workspace;
        }

        public async Task DeleteWorkspaceAsync(int id)
        {
            var workspace = await _context.Workspaces.FindAsync(id);
            if (workspace != null)
            {
                _context.Workspaces.Remove(workspace);
                await _context.SaveChangesAsync();
            }
        }
    }
}