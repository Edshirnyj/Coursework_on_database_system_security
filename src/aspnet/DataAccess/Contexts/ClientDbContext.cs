using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class ClientDbContext(DbContextOptions<ClientDbContext> options) : DbContext(options)
    {
        public DbSet<ClientEntity> Clients { get; set; } = null!;
        public DbSet<ProfileClientEntity> ProfileClients { get; set; } = null!;
        public DbSet<PassportEntity> Passports { get; set; } = null!;
        public DbSet<AutoEntity> Autos { get; set; } = null!;
        public DbSet<DesiredEntity> Desireds { get; set; } = null!;
        public DbSet<TestDriveEntity> TestDrives { get; set; } = null!;
        public DbSet<BrandEntity> Brands { get; set; } = null!;
        public DbSet<ModelEntity> Models { get; set; } = null!;
    }
}