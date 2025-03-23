namespace DataAccess.Entites
{
    public class TradeEntity
    {
        public Guid TradeId { get; private set; } = Guid.NewGuid();
        public string PaymentType { get; private set; } = string.Empty;
        public decimal Price { get; private set; }

    }
}