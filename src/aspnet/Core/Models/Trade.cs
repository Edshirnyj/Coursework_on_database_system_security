namespace Core.Models
{
    public class Trade
    {
        public Guid TradeId { get; private set; } = Guid.NewGuid();
        public string PaymentType { get; private set; } = string.Empty;
        public decimal Price { get; private set; } = 0.00m;

        private Trade(Guid tradeId, string paymentType, decimal price)
        {
            TradeId = tradeId;
            PaymentType = paymentType;
            Price = price;
        }

        public static (Trade? Trade, string Error) Create(Guid tradeId, string paymentType, decimal price)
        {
            string error = ValidateInputs(paymentType, price);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var trade = new Trade(tradeId, paymentType, price);
            return (trade, error);
        }

        private static string ValidateInputs(string paymentType, decimal price)
        {
            if (string.IsNullOrWhiteSpace(paymentType))
                return "Payment type cannot be empty.";

            if (paymentType.Length > 50)
                return "Payment type cannot exceed 50 characters.";

            if (price < 0)
                return "Price cannot be negative.";

            return string.Empty;
        }
    }
}