using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    [Table("contracts")]
    public class ContractEntity
    {
        [Column("contract_id")]
        public Guid ContractId { get; private set; } = Guid.NewGuid();

        [Column("auto_id")]
        public Guid AutoId { get; private set; } = Guid.NewGuid();

        [Column("trade_id")]
        public Guid TradeId { get; private set; } = Guid.NewGuid();

        [Column("typecontract_id")]
        public Guid TypeContractId { get; private set; } = Guid.NewGuid();

        [Column("date_of_contract")]
        public DateTime DateOfContract { get; private set; } = DateTime.UtcNow;


        [ForeignKey(nameof(AutoId))]
        public AutoEntity? Autos { get; set; }

        [ForeignKey(nameof(TradeId))]
        public TradeEntity? Trades { get; set; }

        [ForeignKey(nameof(TypeContractId))]
        public TypeContractEntity? TypeContracts { get; set; }
    }
}