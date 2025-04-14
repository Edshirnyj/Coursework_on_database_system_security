namespace DataAccess.Entites
{
    public class CitizenEntity
    {
        public Guid CitizenId { get; private set; } = Guid.NewGuid();
        public string Location { get; private set; } = string.Empty;
    }
}