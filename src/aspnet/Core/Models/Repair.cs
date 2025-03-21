namespace Core.Models
{
    public class Repair
    {
        public Guid RepairId { get; set; } = Guid.NewGuid();
        public Guid AutoId { get; set; }
        public DateTime DateOfRepair { get; set; }
        public Guid DetailId { get; set; }

        // Navigation properties for foreign keys
        public Auto Auto { get; set; } = null!;
        public Detail Detail { get; set; } = null!;

        private Repair(Guid repairId, Guid autoId, DateTime dateOfRepair, Guid detailId)
        {
            RepairId = repairId;
            AutoId = autoId;
            DateOfRepair = dateOfRepair;
            DetailId = detailId;
        }

        public static (Repair? Repair, string Error) Create(Guid repairId, Guid autoId, DateTime dateOfRepair, Guid detailId)
        {
            string error = string.Empty;

            if (autoId == Guid.Empty)
            {
                error = "AutoId cannot be empty.";
            }

            if (detailId == Guid.Empty)
            {
                error = "DetailId cannot be empty.";
            }

            if (dateOfRepair == default)
            {
                error = "DateOfRepair cannot be default.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var repair = new Repair(repairId, autoId, dateOfRepair, detailId);
            return (repair, error);
        }
    }
}