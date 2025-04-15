namespace DataAccess.Entites
{
    public class HistoryTransformEntity
    {
        public Guid TransformId { get; private set; } = Guid.NewGuid();
        public Guid SalesmanId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public Guid ContractId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        
    }
}