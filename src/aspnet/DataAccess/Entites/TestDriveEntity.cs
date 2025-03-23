namespace DataAccess.Entites
{
    public class TestDriveEntity
    {
        public Guid TestDriveId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; }
        public Guid AutoId { get; private set; }
        public DateTime DateOfTest { get; private set; }
        public string FinePoints { get; private set; } = string.Empty;

    }
}
