using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class DetailConfiguration : IEntityTypeConfiguration<DetailEntity>
    {
        public void Configure(EntityTypeBuilder<DetailEntity> builder)
        {
            builder.ToTable("details");

            builder.HasKey(d => d.DetailId);

            builder.Property(d => d.DetailId)
                .HasColumnName("detail_id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(d => d.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(d => d.Price)
                .HasColumnName("price")
                .HasColumnType("decimal(10, 2)")
                .IsRequired();
        }
    }
}