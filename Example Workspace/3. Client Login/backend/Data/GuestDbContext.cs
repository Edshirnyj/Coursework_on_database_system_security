using Microsoft.EntityFrameworkCore;

namespace fullstack_app.backend.Data
{
    public class GuestDbContext : DbContext
    {
        public GuestDbContext(DbContextOptions<GuestDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Workspace>().ToTable("Workspaces");
            modelBuilder.Entity<Role>().ToTable("Roles");
        }
    }
}