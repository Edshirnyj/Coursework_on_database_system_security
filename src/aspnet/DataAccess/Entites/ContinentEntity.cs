using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    [Table("continents")]
    public class ContinentEntity
    {
        [Column("continent_id")]
        public Guid ContinentId { get; private set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; private set; } = string.Empty;
    }
}