using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class PassportConfiguration : IEntityTypeConfiguration<PassportEntity>
    {
        public void Configure(EntityTypeBuilder<PassportEntity> builder)
        {
            builder.ToTable("passports");

            builder.HasKey(p => p.PassportId);

            builder.Property(p => p.PassportId)
                .HasColumnName("passport_id")
                .IsRequired();

            builder.Property(p => p.Number)
                .HasColumnName("number")
                .IsRequired()
                .HasMaxLength(int.MaxValue);

            builder.Property(p => p.Session)
                .HasColumnName("session")
                .IsRequired()
                .HasMaxLength(int.MaxValue);

            builder.Property(p => p.CitizenId)
                .HasColumnName("citizen_id")
                .IsRequired();

            builder.HasIndex(p => p.Number)
                .IsUnique();

            builder.HasOne<CitizenEntity>()
                .WithMany()
                .HasForeignKey(p => p.CitizenId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}