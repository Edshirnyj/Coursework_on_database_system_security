using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TradeConfiguration : IEntityTypeConfiguration<TradeEntity>
    {
        public void Configure(EntityTypeBuilder<TradeEntity> builder)
        {
            builder.ToTable("trades", t =>
            {
                t.HasCheckConstraint("CK_Price_NonNegative", "price >= 0");
            });

            builder.HasKey(t => t.TradeId);

            builder.Property(t => t.TradeId)
                .HasColumnName("trade_id")
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(t => t.PaymentType)
                .HasColumnName("payment_type")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(t => t.Price)
                .HasColumnName("price")
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            
        }
    }
}