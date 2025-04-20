using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("continents")]
    [PrimaryKey(nameof(ContinentId))]
    public class ContinentEntity
    {
        [Column("continent_id")]
        public Guid ContinentId { get; private set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; private set; } = string.Empty;
    }
}