using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class SalesmanDbContext(DbContextOptions<SalesmanDbContext> options) : DbContext(options)
    {
        public DbSet<SalesmanEntity> Salesmen { get; set; } = null!;
        public DbSet<ProfileSalesmanEntity> ProfileSalesmen { get; set; } = null!;
        public DbSet<HistoryTransformEntity> HistoryTransforms { get; set; } = null!;
        public DbSet<ContractEntity> Contracts { get; set; } = null!;
        public DbSet<TradeEntity> Trades { get; set; } = null!;
        public DbSet<TestDriveEntity> TestDrives { get; set; } = null!;
        public DbSet<AutoEntity> Autos { get; set; } = null!;
        
    }
}