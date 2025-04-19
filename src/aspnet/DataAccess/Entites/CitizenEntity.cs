using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("citizens")]
    [PrimaryKey(nameof(CitizenId))]
    public class CitizenEntity
    {
        [Column("citizen_id")]
        public Guid CitizenId { get; private set; } = Guid.NewGuid();

        [Column("location")]
        public string Location { get; private set; } = string.Empty;

    }
}