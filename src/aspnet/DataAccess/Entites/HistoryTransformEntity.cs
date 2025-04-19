using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("HistoryTransform")]
    [PrimaryKey(nameof(HistoryId))]
    public class HistoryTransformEntity
    {
    
        [Column("history_id")]
        public Guid HistoryId { get; private set; } = Guid.NewGuid();

        [Column("salesman_id")]
        public Guid SalesmanId { get; private set; } = Guid.NewGuid();

        [Column("client_id")]
        public Guid ClientId { get; private set; } = Guid.NewGuid();

        [Column("contract_id")]
        public Guid ContractId { get; private set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; private set; } = string.Empty;


        [ForeignKey(nameof(SalesmanId))]
        public SalesmanEntity? Salesmans { get; set; }

        [ForeignKey(nameof(ClientId))]
        public ClientEntity? Clients { get; set; }

        [ForeignKey(nameof(ContractId))]
        public ContractEntity? Contracts { get; set; }
    }
}