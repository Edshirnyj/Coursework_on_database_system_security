using Microsoft.EntityFrameworkCore;

namespace fullstack_app.backend.Data
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Workspace>()
                .HasKey(w => w.Id);

            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);
        }
    }
}