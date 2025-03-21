using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ContractTypeConfiguration : IEntityTypeConfiguration<ContractTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ContractTypeEntity> builder)
        {
            builder.ToTable("contract_types");

            builder.HasKey(ct => ct.TypeId);

            builder.Property(ct => ct.TypeId)
                .HasColumnName("type_id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(ct => ct.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();
    
                builder.HasIndex(ct => ct.Name)
                    .IsUnique();
        }
    }
}