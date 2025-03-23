namespace Core.Models
{
    public class Shop
    {
        public Guid ShopId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public Guid CarId { get; private set; } = Guid.NewGuid();

        public Client Client { get; private set; } = null!;
        public Auto Auto { get; private set; } = null!;

        private Shop(Guid shopId, Guid clientId, Guid carId)
        {
            ShopId = shopId;
            ClientId = clientId;
            CarId = carId;
        }

        public static (Shop? Shop, string Error) Create(Guid shopId, Guid clientId, Guid carId)
        {
            string error = ValidateInputs(clientId, carId);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var shop = new Shop(shopId, clientId, carId);
            return (shop, error);
        }

        private static string ValidateInputs(Guid clientId, Guid carId)
        {
            if (clientId == Guid.Empty)
            {
                return "ClientId cannot be empty.";
            }

            if (carId == Guid.Empty)
            {
                return "CarId cannot be empty.";
            }

            return string.Empty;
        }
    }
}