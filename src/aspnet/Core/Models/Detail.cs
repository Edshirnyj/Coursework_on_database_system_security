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
            string error = string.Empty;
            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Name cannot be empty.";
            }

            if (price < 0)
            {
                error = "Price cannot be negative.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var detail = new Detail(detailId, name, price);
            return (detail, error);
        }
    }
}