using Microsoft.EntityFrameworkCore;

namespace AspNetApp.Data
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {
        }

        // Define DbSets for admin-related entities here
        // public DbSet<AdminModel> Admins { get; set; }
    }
}