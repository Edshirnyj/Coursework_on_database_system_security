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
        
        [Column("continent_id")]
        public Guid ModelId { get; private set; } = Guid.NewGuid();
        
        [Column("brand_id")]
        public Guid BrandId { get; private set; } = Guid.NewGuid();

    }
}