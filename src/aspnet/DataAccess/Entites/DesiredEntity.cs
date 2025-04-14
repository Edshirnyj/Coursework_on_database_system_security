namespace DataAccess.Entites
{
    public class DesiredEntity
    {
        public Guid DesiredId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public Guid ModelId { get; private set; } = Guid.NewGuid();
        public Guid BrandId { get; private set; } = Guid.NewGuid();

    }
}