namespace Core.Models
{
    public class Trade
    {
        public Guid TradeId { get; set; } = Guid.NewGuid();
        public string PaymentType { get; set; } = string.Empty;
        public decimal Price { get; set; }

        private Trade(Guid tradeId, string paymentType, decimal price)
        {
            TradeId = tradeId;
            PaymentType = paymentType;
            Price = price;
        }

        public static (Trade? Trade, string Error) Create(Guid tradeId, string paymentType, decimal price)
        {
            string error = string.Empty;

            if (string.IsNullOrWhiteSpace(paymentType))
            {
                error = "Payment type cannot be empty.";
            }

            if (price < 0)
            {
                error = "Price cannot be negative.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var trade = new Trade(tradeId, paymentType, price);
            return (trade, error);
        }
    }
}