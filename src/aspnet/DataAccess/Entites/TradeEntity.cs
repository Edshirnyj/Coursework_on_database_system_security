namespace DataAccess.Entites
{
    public class TradeEntity
    {
        public Guid TradeId { get; set; } = Guid.NewGuid();
        public string PaymentType { get; set; } = string.Empty;
        public decimal Price { get; set; }

    }
}