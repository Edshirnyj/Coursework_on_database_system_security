namespace Core.Models
{
    public class TradeModel
    {
        public Guid TradeId { get; set; }
        public string? PaymentType { get; set; }
        public decimal Price { get; set; }

        private TradeModel(Guid tradeId, string? paymentType, decimal price)
        {
            TradeId = tradeId;
            PaymentType = paymentType;
            Price = price;
        }

        public static (TradeModel TradeModel, string Error) Create(Guid tradeId, string? paymentType, decimal price)
        {
            string? error = ValidateInputs(paymentType, price);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var tradeModel = new TradeModel(tradeId, paymentType, price);
            return (tradeModel, string.Empty);
        }

        private static string? ValidateInputs(string? paymentType, decimal price)
        {
            if (string.IsNullOrWhiteSpace(paymentType))
                return "Payment type cannot be empty.";

            if (price <= 0)
                return "Price must be greater than zero.";

            return string.Empty;
        }        
    }
}