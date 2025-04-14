namespace DataAccess.Entites
{
    public class RepairEntity
    {
        public Guid RepairId { get; private set; } = Guid.NewGuid();
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        public DateTime DateOfRepair { get; private set; } = DateTime.Now;
        public Guid DetailId { get; private set; } = Guid.NewGuid();

    }
}