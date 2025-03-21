namespace DataAccess.Entites
{
    public class HistoryTransformEntity
    {
        public Guid TransformId { get; set; } = Guid.NewGuid();
        public Guid ClientId { get; set; }
        public Guid WorkerId { get; set; }
        public Guid ContractId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}