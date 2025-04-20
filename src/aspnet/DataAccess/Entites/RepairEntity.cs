using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("repairs")]
    [PrimaryKey(nameof(RepairId))]
    public class RepairEntity
    {
        [Column("repair_id")]
        public Guid RepairId { get; private set; } = Guid.NewGuid();

        [Column("auto_id")]
        public Guid AutoId { get; private set; } = Guid.NewGuid();

        [Column("date_of_repair")]
        public DateTime DateOfRepair { get; private set; } = DateTime.UtcNow;

        [Column("detail_id")]
        public Guid DetailId { get; private set; } = Guid.NewGuid();

        [Column("mechanic_id")]
        public Guid MechanicId { get; private set; } = Guid.NewGuid();

        
        [ForeignKey(nameof(AutoId))]
        public AutoEntity? Autos { get; set; }

        [ForeignKey(nameof(DetailId))]
        public DetailEntity? Details { get; set; }

        [ForeignKey(nameof(MechanicId))]
        public MechanicEntity? Mechanics { get; set; }
    }
}