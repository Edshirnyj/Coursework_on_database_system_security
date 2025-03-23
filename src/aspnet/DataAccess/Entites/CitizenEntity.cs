namespace DataAccess.Entites
{
    public class CitizenEntity
    {
        public Guid CitizenId { get; set; } = Guid.NewGuid();
        public string Location { get; set; } = null!;

    }
}