namespace Core.Models
{
    public class Detail
    {
        public Guid DetailId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0.00m;

        private Detail(Guid detailId, string name, decimal price)
        {
            DetailId = detailId;
            Name = name;
            Price = price;
        }

        public static (Detail? Detail, string Error) Create(Guid detailId, string name, decimal price)
        {
            string error = ValidateInputs(name, price);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var detail = new Detail(detailId, name, price);
            return (detail, error);
        }

        private static string ValidateInputs(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Name cannot be empty.";

            if (name.Length > 50)
                return "Name cannot exceed 50 characters.";

            if (price < 0)
                return "Price cannot be negative.";

            return string.Empty;
        }
    }
}