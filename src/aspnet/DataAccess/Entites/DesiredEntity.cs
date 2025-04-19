using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    [Table("desireds")]
    public class DesiredEntity
    {
        [Column("desired_id")]
        public Guid DesiredId { get; private set; } = Guid.NewGuid();
        
        [Column("client_id")]
        public Guid ClientId { get; private set; } = Guid.NewGuid();

        [Column("model_id")]
        public Guid ModelId { get; private set; } = Guid.NewGuid();
        
        [Column("brand_id")]
        public Guid BrandId { get; private set; } = Guid.NewGuid();


        [ForeignKey("client_id")]
        public CitizenEntity Client { get; private set; } = new CitizenEntity();

        [ForeignKey("model_id")]
        public ModelEntity Model { get; private set; } = new ModelEntity();

        [ForeignKey("brand_id")]
        public BrandEntity Brand { get; private set; } = new BrandEntity();

    }
}