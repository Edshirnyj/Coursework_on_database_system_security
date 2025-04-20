using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("brands")]
    [PrimaryKey(nameof(BrandId))]
    public class BrandEntity
    {
        [Column("brand_id")]
        public Guid BrandId { get; private set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; private set; } = string.Empty;

        [Column("continent_id")]
        public Guid ContinentId { get; private set; } = Guid.NewGuid();

        
        [ForeignKey(nameof(ContinentId))]
        public ContinentEntity? Continents { get; set; }
    }
}