using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ContinentConfiguration : IEntityTypeConfiguration<ContinentEntity>
    {
        public void Configure(EntityTypeBuilder<ContinentEntity> builder)
        {
            builder.HasKey(e => e.ContinentId);

            builder.Property(e => e.ContinentId)
                .HasColumnName("continent_id")
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(e => e.Name).IsUnique();
        }
    }
}