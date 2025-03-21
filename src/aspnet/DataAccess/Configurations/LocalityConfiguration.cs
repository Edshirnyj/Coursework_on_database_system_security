using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class LocalityConfiguration : IEntityTypeConfiguration<LocalityEntity>
    {
        public void Configure(EntityTypeBuilder<LocalityEntity> builder)
        {
            builder.ToTable("localities");

            builder.HasKey(l => l.LocalityId);

            builder.Property(l => l.LocalityId)
                .HasColumnName("locality_id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(l => l.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();
    
            builder.HasIndex(l => l.Name)
                .IsUnique();
        }
    }
}