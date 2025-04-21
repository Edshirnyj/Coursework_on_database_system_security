using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using fullstack_mini_project.Models;

namespace fullstack_mini_project.Services
{
    public class DatabaseService
    {
        private readonly ApplicationDbContext _context;

        public DatabaseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DatabaseModel>> GetAllRecordsAsync(string tableName)
        {
            return await _context.Set<DatabaseModel>().ToListAsync();
        }

        public async Task<DatabaseModel> GetRecordByIdAsync(int id)
        {
            return await _context.DatabaseModels.FindAsync(id);
        }

        public async Task AddRecordAsync(DatabaseModel record)
        {
            await _context.DatabaseModels.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecordAsync(DatabaseModel record)
        {
            _context.DatabaseModels.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecordAsync(int id)
        {
            var record = await _context.DatabaseModels.FindAsync(id);
            if (record != null)
            {
                _context.DatabaseModels.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}