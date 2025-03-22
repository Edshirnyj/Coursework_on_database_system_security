using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<StatusEntity>
    {
        public void Configure(EntityTypeBuilder<StatusEntity> builder)
        {
            builder.ToTable("statuses");

            builder.HasKey(s => s.StatusId);

            builder.Property(s => s.StatusId)
                   .HasColumnName("status_id")
                   .IsRequired()
                   .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(s => s.Name)
                   .HasColumnName("name")
                   .IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

            builder.HasIndex(s => s.Name)
                   .IsUnique();
        }
    }
}