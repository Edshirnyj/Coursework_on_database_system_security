namespace Core.Models
{
    public class AutoModel
    {
        public Guid AutoId { get; set; }
        public Guid ModelId { get; set; }
        public Guid BrandId { get; set; }
        public int YearOfIssue { get; set; }
        public string? Color { get; set; } 
        public string? Vin { get; set; }
        public string? PhotoPath { get; set; }
        public decimal Mileage { get; set; }
        public Guid StatusId { get; set; }

        private AutoModel(Guid autoId, Guid modelId, Guid brandId, int yearOfIssue, string? color, string? vin, string? photoPath, decimal mileage, Guid statusId)
        {
            AutoId = autoId;
            ModelId = modelId;
            BrandId = brandId;
            YearOfIssue = yearOfIssue;
            Color = color;
            Vin = vin;
            PhotoPath = photoPath;
            Mileage = mileage;
            StatusId = statusId;
        }

        public static (AutoModel AutoModel, string Error) Create(Guid autoId, Guid modelId, Guid brandId, int yearOfIssue, string? color, string? vin, string? photoPath, decimal mileage, Guid statusId)
        {
            string? error = ValidateInputs(modelId, brandId, yearOfIssue, color, vin, photoPath, mileage, statusId);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var autoModel = new AutoModel(autoId, modelId, brandId, yearOfIssue, color, vin, photoPath, mileage, statusId);
            return (autoModel, string.Empty);
        }

        private static string? ValidateInputs(Guid modelId, Guid brandId, int yearOfIssue, string? color, string? vin, string? photoPath, decimal mileage, Guid statusId)
        {
            if (modelId == Guid.Empty)
                return "Model ID cannot be empty.";

            if (brandId == Guid.Empty)
                return "Brand ID cannot be empty.";

            if (yearOfIssue < 1886 || yearOfIssue > DateTime.Now.Year)
                return "Invalid year of issue.";

            if (string.IsNullOrWhiteSpace(vin) || vin.Length != 17)
                return "Invalid VIN.";

            if (mileage < 0)
                return "Mileage cannot be negative.";

            if (statusId == Guid.Empty)
                return "Status ID cannot be empty.";

            return string.Empty;
        }
    }
}