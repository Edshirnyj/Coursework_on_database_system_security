using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AutoConfiguration : IEntityTypeConfiguration<AutoEntity>
    {
        public void Configure(EntityTypeBuilder<AutoEntity> builder)
        {
            builder.ToTable("autos", t =>
            {
                t.HasCheckConstraint("CK_Auto_Year", "year >= 1886");
                t.HasCheckConstraint("CK_Auto_Vin", "octet_length(vin) > 0");
                t.HasCheckConstraint("CK_Auto_Mileage", "mileage >= 0");
            });

            builder.HasKey(a => a.AutoId);
            builder.Property(a => a.AutoId)
                .HasColumnName("auto_id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(a => a.ModelId)
                .HasColumnName("model_id")
                .IsRequired();

            builder.Property(a => a.Year)
                .IsRequired();

            builder.Property(a => a.Vin)
                .HasColumnName("vin")
                    .IsRequired()
                    .HasColumnType("bytea");
    
                builder.HasIndex(a => a.Vin)
                    .IsUnique();

            
            builder.Property(a => a.Mileage)
                .HasColumnName("mileage")
                .IsRequired();

            builder.Property(a => a.StatusId)
                .HasColumnName("status_id");

            builder.HasOne<ModelEntity>()
                .WithMany()
                .HasForeignKey(a => a.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<StatusEntity>()
                .WithMany()
                .HasForeignKey(a => a.StatusId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}