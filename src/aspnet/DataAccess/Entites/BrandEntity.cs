using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    [Table("brands")]
    public class BrandEntity
    {
        [Column("brand_id")]
        public Guid BrandId { get; private set; } = Guid.NewGuid();
        
        [Column("name")]
        public string Name { get; private set; } = string.Empty;
        
        [Column("continent_id")]
        public Guid ContinentId { get; private set; } = Guid.NewGuid();

        
        [ForeignKey("continent_id")]
        public ContinentEntity Continent { get; private set; } = new ContinentEntity();

    }
}