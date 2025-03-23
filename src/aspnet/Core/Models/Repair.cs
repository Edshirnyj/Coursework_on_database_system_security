namespace Core.Models
{
    public class Repair
    {
        public Guid RepairId { get; private set; } = Guid.NewGuid();
        public Guid AutoId { get; private set; }
        public DateTime DateOfRepair { get; private set; }
        public Guid DetailId { get; private set; }

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
            string error = ValidateInputs(autoId, dateOfRepair, detailId);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var repair = new Repair(repairId, autoId, dateOfRepair, detailId);
            return (repair, error);
        }

        private static string ValidateInputs(Guid autoId, DateTime dateOfRepair, Guid detailId)
        {
            if (autoId == Guid.Empty)
            {
                return "AutoId cannot be empty.";
            }

            if (detailId == Guid.Empty)
            {
                return "DetailId cannot be empty.";
            }

            if (dateOfRepair == default)
            {
                return "DateOfRepair cannot be default.";
            }

            return string.Empty;
        }
    }
}