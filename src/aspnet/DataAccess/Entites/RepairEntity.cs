namespace DataAccess.Entites
{
    public class RepairEntity
    {
        public Guid RepairId { get; private set; } = Guid.NewGuid();
        public Guid AutoId { get; private set; }
        public DateTime DateOfRepair { get; private set; }
        public Guid DetailId { get; private set; }

    }
}