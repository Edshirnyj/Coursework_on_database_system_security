using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("desireds")]
    [PrimaryKey(nameof(DesiredId))]
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


        [ForeignKey(nameof(ClientId))]
        public ClientEntity? Clients { get; set; }

        [ForeignKey(nameof(ModelId))]
        public ModelEntity? Models { get; set; }

        [ForeignKey(nameof(BrandId))]
        public BrandEntity? Brands { get; set; }
    }
}