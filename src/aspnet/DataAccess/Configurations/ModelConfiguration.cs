using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ModelConfiguration : IEntityTypeConfiguration<ModelEntity>
    {
        public void Configure(EntityTypeBuilder<ModelEntity> builder)
        {
            builder.ToTable("models");

            builder.HasKey(m => m.ModelId);

            builder.Property(m => m.ModelId)
                .HasColumnName("model_id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(m => m.BrandId)
                .HasColumnName("brand_id")
                .IsRequired();

            builder.Property(m => m.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(m => m.Name)
                .IsUnique();

            builder.HasOne<BrandEntity>()
                .WithMany()
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}