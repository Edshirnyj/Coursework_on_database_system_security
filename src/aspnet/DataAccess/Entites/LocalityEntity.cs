namespace DataAccess.Entites
{
    public class LocalityEntity
    {
        public Guid LocalityId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }
    
}