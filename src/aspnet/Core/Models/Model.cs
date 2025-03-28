namespace Core.Models
{
    public class Model
    {
        public Guid ModelId { get; private set; } = Guid.NewGuid();
        public Guid BrandId { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public Brand Brand { get; private set; } = null!;

        private Model(Guid modelId, Guid brandId, string name)
        {
            ModelId = modelId;
            BrandId = brandId;
            Name = name;
        }

        public static (Model? Model, string Error) Create(Guid modelId, Guid brandId, string name)
        {
            string error = ValidateInputs(brandId, name);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var model = new Model(modelId, brandId, name);
            return (model, error);
        }
    

        private static string ValidateInputs(Guid brandId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Name cannot be empty.";
            }

            if (brandId == Guid.Empty)
            {
                return "BrandId cannot be empty.";
            }

            return string.Empty;
        }
    }
}