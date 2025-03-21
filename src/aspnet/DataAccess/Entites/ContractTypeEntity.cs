namespace DataAccess.Entites
{
    public class ContractTypeEntity
    {
        public Guid TypeId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }
    
}