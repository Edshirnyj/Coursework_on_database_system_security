namespace DataAccess.Entites
{
    public class StatusEntity
    {
        public Guid StatusId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }
    
}