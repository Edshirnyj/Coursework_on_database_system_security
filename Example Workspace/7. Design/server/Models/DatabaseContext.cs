using Microsoft.EntityFrameworkCore;

namespace fullstack_mini_project.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        // Define your DbSets (tables) here
        // public DbSet<YourModel> YourModels { get; set; }
    }
}