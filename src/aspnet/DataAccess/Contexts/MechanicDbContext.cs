using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class MechanicDbContext(DbContextOptions<MechanicDbContext> options) : DbContext(options)
    {
        public DbSet<RepairEntity> Repairs { get; set; } = null!;
        public DbSet<DetailEntity> Details { get; set; } = null!;
        public DbSet<MechanicEntity> Mechanics { get; set; } = null!;
        public DbSet<ProfileMechanicEntity> ProfileMechanics { get; set; } = null!;
        public DbSet<AutoEntity> Autos { get; set; } = null!;   
    }
}