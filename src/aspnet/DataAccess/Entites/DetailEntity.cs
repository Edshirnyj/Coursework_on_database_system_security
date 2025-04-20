using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("details")]
    [PrimaryKey(nameof(DetailId))]
    public class DetailEntity
    {
        [Column("detail_id")]
        public Guid DetailId { get; private set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; private set; } = string.Empty;

        [Column("price")]
        public decimal Price { get; private set; } = 0.0m;
    }
}