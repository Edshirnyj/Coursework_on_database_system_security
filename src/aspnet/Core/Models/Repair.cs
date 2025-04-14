namespace Core.Models
{
    public class Repair
    {
        public Guid RepairId { get; private set; } = Guid.NewGuid();
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        public DateTime DateOfRepair { get; private set; } = DateTime.Now;
        public Guid DetailId { get; private set; } = Guid.NewGuid();

        public Auto Auto { get; private set; } = null!;
        public Detail Detail { get; private set; } = null!;

        private Repair(Guid repairId, Guid autoId, DateTime dateOfRepair, Guid detailId)
        {
            RepairId = repairId;
            AutoId = autoId;
            DateOfRepair = dateOfRepair;
            DetailId = detailId;
        }

        public static (Repair? Repair, string Error) Create(Guid repairId, Guid autoId, DateTime dateOfRepair, Guid detailId)
        {
            string error = ValidateInputs(autoId, detailId, dateOfRepair);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var repair = new Repair(repairId, autoId, dateOfRepair, detailId);
            return (repair, error);
        }

        private static string ValidateInputs(Guid autoId, Guid detailId, DateTime dateOfRepair)
        {
            if (autoId == Guid.Empty)
                return "Auto ID cannot be empty.";

            if (detailId == Guid.Empty)
                return "Detail ID cannot be empty.";

            if (dateOfRepair > DateTime.Now)
                return "Date of repair cannot be in the future.";

            return string.Empty;
        }
    }
}