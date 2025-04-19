using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    [Table("models")]
    public class ModelEntity
    {
        [Column("model_id")]
        public Guid ModelId { get; private set; } = Guid.NewGuid();
        
        [Column("name")]
        public string Name { get; private set; } = string.Empty;
        
        [Column("brand_id")]
        public Guid BrandId { get; private set; } = Guid.NewGuid();


        [ForeignKey("brand_id")]
        public BrandEntity Brand { get; private set; } = new BrandEntity();
        
    }
}