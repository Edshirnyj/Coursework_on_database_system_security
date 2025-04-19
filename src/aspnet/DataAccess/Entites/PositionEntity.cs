using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("positions")]
    [PrimaryKey(nameof(PositionId))]
    public class PositionEntity
    {
        [Column("position_id")]
        public Guid PositionId { get; private set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; private set; } = string.Empty;
    }
}