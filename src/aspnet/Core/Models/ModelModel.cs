namespace Core.Models
{
    public class ModelModel
    {
        public Guid ModelId { get; set; }
        public string? Name { get; set; }
        public Guid BrandId { get; set; }

        private ModelModel(Guid modelId, string? name, Guid brandId)
        {
            ModelId = modelId;
            Name = name;
            BrandId = brandId;
        }

        public static (ModelModel ModelModel, string Error) Create(Guid modelId, string? name, Guid brandId)
        {
            string? error = ValidateInputs(name, brandId);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var modelModel = new ModelModel(modelId, name, brandId);
            return (modelModel, string.Empty);
        }

        private static string? ValidateInputs(string? name, Guid brandId)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Model name cannot be empty.";

            if (brandId == Guid.Empty)
                return "Brand ID cannot be empty.";

            return string.Empty;
        }
    }
}