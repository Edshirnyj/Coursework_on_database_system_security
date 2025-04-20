using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("statuses")]
    [PrimaryKey(nameof(StatusId))]
    public class StatusEntity
    {
        [Column("status_id")]
        public Guid StatusId { get; private set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; private set; } = string.Empty;
    }
}