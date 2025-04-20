namespace Core.Models
{
    public class DetailModel
    {
        public Guid DetailId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        private DetailModel(Guid detailId, string? name, decimal price)
        {
            DetailId = detailId;
            Name = name;
            Price = price;
        }

        public static (DetailModel DetailModel, string Error) Create(Guid detailId, string? name, decimal price)
        {
            string? error = ValidateInputs(name, price);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var detailModel = new DetailModel(detailId, name, price);
            return (detailModel, string.Empty);
        }

        private static string? ValidateInputs(string? name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Detail name cannot be empty.";

            if (price <= 0)
                return "Price must be greater than zero.";

            return string.Empty;
        }        
    }
}