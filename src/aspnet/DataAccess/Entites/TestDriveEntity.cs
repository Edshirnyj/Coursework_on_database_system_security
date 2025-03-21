namespace DataAccess.Entites
{
    public class TestDriveEntity
    {
        public Guid TestDriveId { get; set; } = Guid.NewGuid();
        public Guid ClientId { get; set; }
        public Guid AutoId { get; set; }
        public DateTime DateOfTest { get; set; }
        public string FinePoints { get; set; } = string.Empty;
    }
}
