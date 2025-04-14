namespace DataAccess.Entites
{
    public class StatusEntity
    {
        public Guid StatusId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
    }  
}