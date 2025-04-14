namespace Core.Models
{
    public class Auto
    {
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        public Guid ModelId { get; private set; } = Guid.NewGuid();
        public int Year { get; private set; } = DateTime.Now.Year;
        public string Color { get; private set; } = string.Empty;
        public byte[] Vin { get; private set; } = [];
        public string PhotoPath { get; private set; } = string.Empty;
        public int Mileage { get; private set; } = 0;
        public Guid? StatusId { get; private set; } = null;

        public Model Model { get; private set; } = null!;
        public Status Status { get; private set; } = null!;

        private Auto(Guid autoId, Guid modelId, int year, string color, byte[] vin, string photoPath, int mileage, Guid? statusId)
        {
            AutoId = autoId;
            ModelId = modelId;
            Year = year;
            Color = color;
            Vin = vin;
            PhotoPath = photoPath;
            Mileage = mileage;
            StatusId = statusId;
        }

        public static (Auto? Auto, string Error) Create(Guid autoId, Guid modelId, int year, string color, byte[] vin, string photoPath, int mileage, Guid? statusId)
        {
            string error = ValidateInputs(modelId, year, color, vin, photoPath, mileage);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var auto = new Auto(autoId, modelId, year, color, vin, photoPath, mileage, statusId);
            return (auto, error);
        }

        private static string ValidateInputs(Guid modelId, int year, string color, byte[] vin, string photoPath, int mileage)
        {
            if (modelId == Guid.Empty)
                return "Model ID cannot be empty.";

            if (year < 1886 || year > DateTime.Now.Year + 1)
                return "Year must be between 1886 and next year.";

            if (string.IsNullOrWhiteSpace(color))
                return "Color cannot be empty.";

            if (vin.Length != 17)
                return "VIN must be exactly 17 characters.";

            if (!string.IsNullOrEmpty(photoPath) && !System.IO.File.Exists(photoPath))
                return "Photo file does not exist.";

            if (mileage < 0)
                return "Mileage cannot be negative.";

            return string.Empty;
        }        
    }
}