namespace Core.Models
{
    public class BrandModel
    {
        public Guid BrandId { get; set; }
        public string? Name { get; set; }
        public Guid ContinentId { get; set; }

        private BrandModel(Guid brandId, string? name, Guid continentId)
        {
            BrandId = brandId;
            Name = name;
            ContinentId = continentId;
        }

        public static (BrandModel BrandModel, string Error) Create(Guid brandId, string? name, Guid continentId)
        {
            string? error = ValidateInputs(name, continentId);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var brandModel = new BrandModel(brandId, name, continentId);
            return (brandModel, string.Empty);
        }

        private static string? ValidateInputs(string? name, Guid continentId)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Brand name cannot be empty.";

            if (continentId == Guid.Empty)
                return "Continent ID cannot be empty.";

            return string.Empty;
        }
    }
}