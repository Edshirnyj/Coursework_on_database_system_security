namespace Core.Models
{
    public class DesiredModel
    {
        public Guid DesiredId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ModelId { get; set; }
        public Guid BrandId { get; set; }

        private DesiredModel(Guid desiredId, Guid clientId, Guid modelId, Guid brandId)
        {
            DesiredId = desiredId;
            ClientId = clientId;
            ModelId = modelId;
            BrandId = brandId;
        }

        public static (DesiredModel DesiredModel, string Error) Create(Guid desiredId, Guid clientId, Guid modelId, Guid brandId)
        {
            string? error = ValidateInputs(clientId, modelId, brandId);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var desiredModel = new DesiredModel(desiredId, clientId, modelId, brandId);
            return (desiredModel, string.Empty);
        }

        private static string? ValidateInputs(Guid clientId, Guid modelId, Guid brandId)
        {
            if (clientId == Guid.Empty)
                return "Client ID cannot be empty.";

            if (modelId == Guid.Empty)
                return "Model ID cannot be empty.";

            if (brandId == Guid.Empty)
                return "Brand ID cannot be empty.";

            return string.Empty;
        }        
    }
}