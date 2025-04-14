namespace DataAccess.Entites
{
    public class TestDriveEntity
    {
        public Guid TestId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        public DateTime DateOfTest { get; private set; } = DateTime.Now;
        public string FinePoints { get; private set; } = string.Empty;

    }
}
