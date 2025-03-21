using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.HasKey(e => e.ClientId);

            builder.Property(e => e.ClientId)
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.SecondName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.ThirdName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasColumnType("bytea")
                .HasAnnotation("CheckConstraint", "octet_length(phone) > 0");
            builder.HasIndex(e => e.Phone).IsUnique();

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnType("bytea")
                .HasAnnotation("CheckConstraint", "octet_length(email) > 0");
            builder.HasIndex(e => e.Email).IsUnique();

            builder.Property(e => e.PassportId)
                .IsRequired();

            builder.HasOne<PassportEntity>()
                .WithMany()
                .HasForeignKey(e => e.PassportId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}