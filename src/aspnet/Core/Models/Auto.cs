namespace Core.Models
{
    public class Auto
    {
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        public Guid ModelId { get; private set; }
        public int Year { get; private set; }
        public string Color { get; private set; } = string.Empty;
        public byte[] Vin { get; private set; } = Array.Empty<byte>();
        public int Mileage { get; private set; }
        public Guid? StatusId { get; private set; }

        public Model Model { get; private set; } = null!;
        public Status Status { get; private set; } = null!;

        private Auto(Guid autoId, Guid modelId, int year, string color, byte[] vin, int mileage, Guid? statusId)
        {
            AutoId = autoId;
            ModelId = modelId;
            Year = year;
            Color = color;
            Vin = vin;
            Mileage = mileage;
            StatusId = statusId;
        }

        public static (Auto? Auto, string Error) Create(Guid autoId, Guid modelId, int year, string color, byte[] vin, int mileage, Guid? statusId)
        {
            string error = ValidateInputs(modelId, year, vin, mileage);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var auto = new Auto(autoId, modelId, year, SanitizeInput(color), vin, mileage, statusId);
            return (auto, string.Empty);
        }

        private static string ValidateInputs(Guid modelId, int year, byte[] vin, int mileage)
        {
            if (year < 1886)
            {
                return "Year must be 1886 or later.";
            }

            if (vin == null || vin.Length == 0)
            {
                return "VIN cannot be empty.";
            }

            if (mileage < 0)
            {
                return "Mileage cannot be negative.";
            }

            if (modelId == Guid.Empty)
            {
                return "ModelId cannot be empty.";
            }

            return string.Empty;
        }

        private static string SanitizeInput(string input)
        {
            // Sanitize input to prevent SQL injection or other malicious input
            return input.Replace("'", "''").Trim();
        }
    }
}