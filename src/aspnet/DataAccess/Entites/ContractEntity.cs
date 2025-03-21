namespace DataAccess.Entites
{
    public class ContractEntity
    {
        public Guid ContractId { get; set; } = Guid.NewGuid();
        public Guid AutoId { get; set; }
        public Guid TradeId { get; set; }
        public Guid ContractTypeId { get; set; }
        public DateTime DateOfContract { get; set; }

        
    }
}
