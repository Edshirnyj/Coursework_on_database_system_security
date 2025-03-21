namespace DataAccess.Entites
{
    public class CitizenEntity
    {
        public Guid CitizenId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public Guid LocalityId { get; set; }
    }
}