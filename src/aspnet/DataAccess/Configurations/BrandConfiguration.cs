using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<BrandEntity>
    {
        public void Configure(EntityTypeBuilder<BrandEntity> builder)
        {
            builder.ToTable("brands");

            builder.HasKey(b => b.BrandId);
            builder.Property(b => b.BrandId)
                .HasColumnName("brand_id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(b => b.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(b => b.ContinentId)
                .HasColumnName("continent_id")
                .IsRequired();

            builder.HasOne<ContinentEntity>()
                .WithMany()
                .HasForeignKey(b => b.ContinentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}