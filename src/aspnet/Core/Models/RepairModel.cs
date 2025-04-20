namespace Core.Models
{
    public class RepairModel
    {
        public Guid RepairId { get; set; }
        public Guid AutoId { get; set; }
        public DateTime DateOfRepair { get; set; }
        public Guid DetailId { get; set; }
        public Guid MechanicId { get; set; }

        private RepairModel(Guid repairId, Guid autoId, DateTime dateOfRepair, Guid detailId, Guid mechanicId)
        {
            RepairId = repairId;
            AutoId = autoId;
            DateOfRepair = dateOfRepair;
            DetailId = detailId;
            MechanicId = mechanicId;
        }

        public static (RepairModel RepairModel, string Error) Create(Guid repairId, Guid autoId, DateTime dateOfRepair, Guid detailId, Guid mechanicId)
        {
            string? error = ValidateInputs(autoId, detailId, mechanicId);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var repairModel = new RepairModel(repairId, autoId, dateOfRepair, detailId, mechanicId);
            return (repairModel, string.Empty);
        }

        private static string? ValidateInputs(Guid autoId, Guid detailId, Guid mechanicId)
        {
            if (autoId == Guid.Empty)
                return "Auto ID cannot be empty.";

            if (detailId == Guid.Empty)
                return "Detail ID cannot be empty.";

            if (mechanicId == Guid.Empty)
                return "Mechanic ID cannot be empty.";

            return string.Empty;
        }        
    }
}