using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class SalesmanDbContext(DbContextOptions<SalesmanDbContext> options) : DbContext(options)
    {
        public DbSet<AutoEntity> Autos { get; set; } = null!;
        public DbSet<BrandEntity> Brands { get; set; } = null!;
        public DbSet<CitizenEntity> Citizens { get; set; } = null!;
        public DbSet<ClientEntity> Clients { get; set; } = null!;
        public DbSet<ContinentEntity> Continents { get; set; } = null!;
        public DbSet<ContractEntity> Contracts { get; set; } = null!;
        public DbSet<DesiredEntity> Desireds { get; set; } = null!;
        public DbSet<DetailEntity> Details { get; set; } = null!;
        public DbSet<HistoryTransformEntity> HistoryTransforms { get; set; } = null!;
        public DbSet<MechanicEntity> Mechanics { get; set; } = null!;
        public DbSet<ModelEntity> Models { get; set; } = null!;
        public DbSet<PassportEntity> Passports { get; set; } = null!;
        public DbSet<PositionEntity> Positions { get; set; } = null!;
        public DbSet<ProfileClientEntity> ProfileClients { get; set; } = null!;
        public DbSet<ProfileMechanicEntity> ProfileMechanics { get; set; } = null!;
        public DbSet<ProfileSalesmanEntity> ProfileSalesmans { get; set; } = null!;
        public DbSet<RepairEntity> Repairs { get; set; } = null!;
        public DbSet<SalesmanEntity> Salesmans { get; set; } = null!;
        public DbSet<StatusEntity> Statuses { get; set; } = null!;
        public DbSet<TestDriveEntity> TestDrives { get; set; } = null!;
        public DbSet<TradeEntity> Trades { get; set; } = null!;
        public DbSet<TypeContractEntity> TypeContracts { get; set; } = null!;
        
    }
}