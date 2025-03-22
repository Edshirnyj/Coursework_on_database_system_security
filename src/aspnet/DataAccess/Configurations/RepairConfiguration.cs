using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class RepairConfiguration : IEntityTypeConfiguration<RepairEntity>
    {
        public void Configure(EntityTypeBuilder<RepairEntity> builder)
        {
            builder.ToTable("repairs");

            builder.HasKey(r => r.RepairId);

            builder.Property(r => r.RepairId)
                .HasColumnName("repair_id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(r => r.AutoId)
                .HasColumnName("auto_id")
                .IsRequired();

            builder.Property(r => r.DateOfRepair)
                .HasColumnName("date_of_repair")
                .IsRequired();

            builder.Property(r => r.DetailId)
                .HasColumnName("detail_id")
                .IsRequired();

            builder.HasOne<AutoEntity>()
                .WithMany()
                .HasForeignKey(r => r.AutoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<DetailEntity>()
                .WithMany()
                .HasForeignKey(r => r.DetailId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}