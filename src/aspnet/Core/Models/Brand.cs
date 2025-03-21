namespace Core.Models
{
    public class Brand
    {
        public Guid BrandId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public Guid ContinentId { get; set; }

        // Navigation property for the foreign key
        public Continent Continent { get; set; } = null!;

        private Brand(Guid brandId, string name, Guid continentId)
        {
            BrandId = brandId;
            Name = name;
            ContinentId = continentId;
        }

        public static (Brand? Brand, string Error) Create(Guid brandId, string name, Guid continentId)
        {
            string error = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Name cannot be empty.";
            }

            if (continentId == Guid.Empty)
            {
                error = "ContinentId cannot be empty.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var brand = new Brand(brandId, name, continentId);
            return (brand, error);
        }
    }
}