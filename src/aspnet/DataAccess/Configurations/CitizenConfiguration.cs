using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class CitizenConfiguration : IEntityTypeConfiguration<CitizenEntity>
    {
        public void Configure(EntityTypeBuilder<CitizenEntity> builder)
        {
            builder.ToTable("citizens");

            builder.HasKey(c => c.CitizenId);

            builder.Property(c => c.CitizenId)
                .HasColumnName("citizen_id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.LocalityId)
                .HasColumnName("locality_id")
                .IsRequired();

            builder.HasOne<LocalityEntity>()
                .WithMany()
                .HasForeignKey(c => c.LocalityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}