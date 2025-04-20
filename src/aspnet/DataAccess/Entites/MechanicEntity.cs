using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("mechanics")]
    [PrimaryKey(nameof(MechanicId))]
    public class MechanicEntity
    {
        [Column("mechanic_id")]
        public Guid MechanicId { get; private set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; private set; } = string.Empty;

        [Column("surname")]
        public string Surname { get; private set; } = string.Empty;

        [Column("patronymic")]
        public string Patronymic { get; private set; } = string.Empty;

        [Column("position_id")]
        public Guid PositionId { get; private set; } = Guid.NewGuid();

        
        [ForeignKey(nameof(PositionId))]
        public PositionEntity? Position { get; set; } 
    }
}