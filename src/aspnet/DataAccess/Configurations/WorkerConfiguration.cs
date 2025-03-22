using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class WorkerConfiguration : IEntityTypeConfiguration<WorkerEntity>
    {
        public void Configure(EntityTypeBuilder<WorkerEntity> builder)
        {
            builder.ToTable("workers");

            builder.HasKey(w => w.WorkerId);

            builder.Property(w => w.WorkerId)
                .HasColumnName("worker_id")
                .IsRequired();

            builder.Property(w => w.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(w => w.SecondName)
                .HasColumnName("second_name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(w => w.ThirdName)
                .HasColumnName("third_name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(w => w.Position)
                .HasColumnName("position")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(w => w.Cost)
                .HasColumnName("cost")
                .IsRequired();
        }
    }
}