using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("trades")]
    [PrimaryKey(nameof(TradeId))]
    public class TradeEntity
    {
        [Column("trade_id")]
        public Guid TradeId { get; private set; } = Guid.NewGuid();

        [Column("payment_type")]
        public string PaymentType { get; private set; } = string.Empty;

        [Column("price")]
        public decimal Price { get; private set; } = 0.0m;
    }
}