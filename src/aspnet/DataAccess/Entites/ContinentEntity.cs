namespace DataAccess.Entites
{
    public class ContinentEntity
    {
        public Guid ContinentId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }
}