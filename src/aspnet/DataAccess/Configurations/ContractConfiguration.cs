using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<ContractEntity>
    {
        public void Configure(EntityTypeBuilder<ContractEntity> builder)
        {
            builder.ToTable("contracts");

            builder.HasKey(c => c.ContractId);

            builder.Property(c => c.ContractId)
                .HasColumnName("contract_id")
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(c => c.AutoId)
                .HasColumnName("auto_id")
                .IsRequired();

            builder.Property(c => c.TradeId)
                .HasColumnName("trade_id")
                .IsRequired();

            builder.Property(c => c.ContractTypeId)
                .HasColumnName("contract_type_id")
                .IsRequired();

            builder.Property(c => c.DateOfContract)
                .HasColumnName("date_of_contract")
                .IsRequired();

            builder.HasOne<AutoEntity>()
                .WithMany()
                .HasForeignKey(c => c.AutoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<TradeEntity>()
                .WithMany()
                .HasForeignKey(c => c.TradeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<ContractTypeEntity>()
                .WithMany()
                .HasForeignKey(c => c.ContractTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}