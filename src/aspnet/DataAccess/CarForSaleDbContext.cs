
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CarForSaleDbContext : DbContext
    {
        public CarForSaleDbContext(DbContextOptions<CarForSaleDbContext> options) : base(options)
        {
        }

        public DbSet<AutoEntity> Autos { get; set; } = null!;
        public DbSet<BrandEntity> Brands { get; set; } = null!;
        public DbSet<CitizenEntity> Citizens { get; set; } = null!;
        public DbSet<ClientEntity> Clients { get; set; } = null!;
        public DbSet<ContinentEntity> Continents { get; set; } = null!;
        public DbSet<ContractEntity> Countries { get; set; } = null!;
        public DbSet<ContractTypeEntity> ContractTypes { get; set; } = null!;
        public DbSet<HistoryTransformEntity> HistoryTransforms { get; set; } = null!;
        public DbSet<LocalityEntity> Localities { get; set; } = null!;
        public DbSet<ModelEntity> Models { get; set; } = null!;
        public DbSet<PassportEntity> Passports { get; set; } = null!;
        public DbSet<RepairEntity> Repairs { get; set; } = null!;
        public DbSet<StatusEntity> Statuses { get; set; } = null!;
        public DbSet<TestDriveEntity> TestDrives { get; set; } = null!;
        public DbSet<TradeEntity> Trades { get; set; } = null!;
        public DbSet<WorkerEntity> Workers { get; set; } = null!;
        
    }
}