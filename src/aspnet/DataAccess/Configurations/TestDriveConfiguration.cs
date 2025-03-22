using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TestDriveConfiguration : IEntityTypeConfiguration<TestDriveEntity>
    {
        public void Configure(EntityTypeBuilder<TestDriveEntity> builder)
        {
            builder.ToTable("test_drives");

            builder.HasKey(t => t.TestDriveId);

            builder.Property(t => t.TestDriveId)
                .HasColumnName("test_drive_id")
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(t => t.ClientId)
                .HasColumnName("client_id")
                .IsRequired();

            builder.Property(t => t.AutoId)
                .HasColumnName("auto_id")
                .IsRequired();

            builder.Property(t => t.DateOfTest)
                .HasColumnName("date_of_test")
                .IsRequired();

            builder.Property(t => t.FinePoints)
                .HasColumnName("fine_points")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne<ClientEntity>()
                .WithMany()
                .HasForeignKey(t => t.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<AutoEntity>()
                .WithMany()
                .HasForeignKey(t => t.AutoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}