namespace DataAccess.Entites
{
    public class RepairEntity
    {
        public Guid RepairId { get; set; } = Guid.NewGuid();
        public Guid AutoId { get; set; }
        public DateTime DateOfRepair { get; set; }
        public Guid DetailId { get; set; }
    }
    
}