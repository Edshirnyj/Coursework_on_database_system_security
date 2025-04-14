namespace DataAccess.Entites
{
    public class ContractEntity
    {
        public Guid ContractId { get; private set; } = Guid.NewGuid();
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        public Guid TradeId { get; private set; } = Guid.NewGuid();
        public Guid TypeContractId { get; private set; } = Guid.NewGuid();
        public DateTime DateOfContract { get; private set; } = DateTime.Now;
    }
}
