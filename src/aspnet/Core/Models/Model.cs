namespace Core.Models
{
    public class Model
    {
        public Guid ModelId { get; set; } = Guid.NewGuid();
        public Guid BrandId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation property for the foreign key
        public Brand Brand { get; set; } = null!;

        private Model(Guid modelId, Guid brandId, string name)
        {
            ModelId = modelId;
            BrandId = brandId;
            Name = name;
        }

        public static (Model? Model, string Error) Create(Guid modelId, Guid brandId, string name)
        {
            string error = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Name cannot be empty.";
            }

            if (brandId == Guid.Empty)
            {
                error = "BrandId cannot be empty.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var model = new Model(modelId, brandId, name);
            return (model, error);
        }
    }
}