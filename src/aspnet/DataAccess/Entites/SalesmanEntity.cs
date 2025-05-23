using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("salesmans")]
    [PrimaryKey(nameof(SalesmanId))]
    public class SalesmanEntity
    {
        [Column("salesman_id")]
        public Guid SalesmanId { get; private set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; private set; } = string.Empty;

        [Column("surname")]
        public string Surname { get; private set; } = string.Empty;

        [Column("patronymic")]
        public string Patronymic { get; private set; } = string.Empty;

        [Column("position_id")]
        public Guid PositionId { get; private set; } = Guid.NewGuid();

        
        [ForeignKey(nameof(PositionId))]
        public PositionEntity? Positions { get; set; }
    }
}