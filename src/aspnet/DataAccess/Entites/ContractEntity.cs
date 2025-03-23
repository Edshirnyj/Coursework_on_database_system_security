namespace DataAccess.Entites
{
    public class ContractEntity
    {
        public Guid ContractId { get; private set; } = Guid.NewGuid();
        public Guid AutoId { get; private set; }
        public Guid TradeId { get; private set; }
        public Guid ContractTypeId { get; private set; }
        public DateTime DateOfContract { get; private set; }

    }
}
