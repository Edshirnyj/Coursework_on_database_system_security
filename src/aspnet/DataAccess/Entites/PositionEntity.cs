using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    [Table("positions")]
    public class PositionEntity
    {
        [Column("position_id")]
        public Guid PositionId { get; private set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; private set; } = string.Empty;
    }
}