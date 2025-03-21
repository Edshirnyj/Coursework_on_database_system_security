using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class HistoryTransformConfiguration : IEntityTypeConfiguration<HistoryTransformEntity>
    {
        public void Configure(EntityTypeBuilder<HistoryTransformEntity> builder)
        {
            builder.ToTable("history_transforms");

            builder.HasKey(ht => ht.TransformId);

            builder.Property(ht => ht.TransformId)
                .HasColumnName("transform_id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(ht => ht.ClientId)
                .HasColumnName("client_id")
                .IsRequired();

            builder.Property(ht => ht.WorkerId)
                .HasColumnName("worker_id")
                .IsRequired();

            builder.Property(ht => ht.ContractId)
                .HasColumnName("contract_id")
                .IsRequired();

            builder.Property(ht => ht.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne<ClientEntity>()
                .WithMany()
                .HasForeignKey(ht => ht.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<WorkerEntity>()
                .WithMany()
                .HasForeignKey(ht => ht.WorkerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<ContractEntity>()
                .WithMany()
                .HasForeignKey(ht => ht.ContractId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}