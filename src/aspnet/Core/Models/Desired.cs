namespace Core.Models
{
    public class Desired
    {
        public Guid DesiredId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public Guid ModelId { get; private set; } = Guid.NewGuid();
        public Guid BrandId { get; private set; } = Guid.NewGuid();

        public Client Client { get; private set; } = null!;
        public Model Model { get; private set; } = null!;
        public Brand Brand { get; private set; } = null!;

        private Desired(Guid desiredId, Guid clientId, Guid modelId, Guid brandId)
        {
            DesiredId = desiredId;
            ClientId = clientId;
            ModelId = modelId;
            BrandId = brandId;
        }

        public static (Desired? Desired, string Error) Create(Guid desiredId, Guid clientId, Guid modelId, Guid brandId)
        {
            string error = ValidateInputs(clientId, modelId, brandId);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var desired = new Desired(desiredId, clientId, modelId, brandId);
            return (desired, error);
        }

        private static string ValidateInputs(Guid clientId, Guid modelId, Guid brandId)
        {
            if (clientId == Guid.Empty)
            {
                return "ClientId cannot be empty.";
            }

            if (modelId == Guid.Empty)
            {
                return "ModelId cannot be empty.";
            }

            if (brandId == Guid.Empty)
            {
                return "BrandId cannot be empty.";
            }

            return string.Empty;
        }
    }
}