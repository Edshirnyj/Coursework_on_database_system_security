namespace DataAccess.Entites
{
    public class ContractTypeEntity
    {
        public Guid TypeId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;

    }
}