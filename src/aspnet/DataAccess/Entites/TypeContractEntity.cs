namespace DataAccess.Entites
{
    public class TypeContractEntity
    {
        public Guid TypeContractId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
    }
}