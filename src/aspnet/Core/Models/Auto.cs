namespace Core.Models
{
    public class Auto
    {
        public Guid AutoId { get; set; } = Guid.NewGuid();
        public Guid ModelId { get; set; }
        public int Year { get; set; }
        public byte[] Vin { get; set; } = [];
        public int Mileage { get; set; }
        public Guid? StatusId { get; set; }

        // Navigation properties for foreign keys
        public Model Model { get; set; } = null!;
        public Status Status { get; set; } = null!;

        private Auto(Guid autoId, Guid modelId, int year, byte[] vin, int mileage, Guid? statusId)
        {
            AutoId = autoId;
            ModelId = modelId;
            Year = year;
            Vin = vin;
            Mileage = mileage;
            StatusId = statusId;
        }

        public static (Auto? Auto, string Error) Create(Guid autoId, Guid modelId, int year, byte[] vin, int mileage, Guid? statusId)
        {
            string error = string.Empty;

            if (year < 1886)
            {
                error = "Year must be 1886 or later.";
            }

            if (vin == null || vin.Length == 0)
            {
                error = "VIN cannot be empty.";
            }

            if (mileage < 0)
            {
                error = "Mileage cannot be negative.";
            }

            if (modelId == Guid.Empty)
            {
                error = "ModelId cannot be empty.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var auto = new Auto(autoId, modelId, year, vin!, mileage, statusId);
            return (auto, error);
        }
    }
}