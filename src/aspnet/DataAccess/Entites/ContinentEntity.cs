namespace DataAccess.Entites
{
    public class ContinentEntity
    {
        public Guid ContinentId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
    }
}