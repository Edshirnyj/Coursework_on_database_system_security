namespace Core.Models
{
    public class Brand
    {
        public Guid BrandId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public Guid ContinentId { get; private set; }

        public Continent Continent { get; private set; } = null!;

        private Brand(Guid brandId, string name, Guid continentId)
        {
            BrandId = brandId;
            Name = name;
            ContinentId = continentId;
        }

        public static (Brand? Brand, string Error) Create(Guid brandId, string name, Guid continentId)
        {
            string error = ValidateInputs(name, continentId);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var brand = new Brand(brandId, name, continentId);
            return (brand, error);
        }

        private static string ValidateInputs(string name, Guid continentId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Name cannot be empty.";
            }

            if (continentId == Guid.Empty)
            {
                return "ContinentId cannot be empty.";
            }

            return string.Empty;
        }
    }
}