using Microsoft.EntityFrameworkCore;

namespace AspNetApp.Data
{
    public class SalesmanDbContext : DbContext
    {
        public SalesmanDbContext(DbContextOptions<SalesmanDbContext> options) : base(options)
        {
        }

        // Define DbSets for your salesman-related entities here
        // public DbSet<SalesmanModel> Salesmen { get; set; }
    }
}