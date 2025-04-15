using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    [Table("citizens")]
    public class CitizenEntity
    {
        [Column("citizen_id")]
        public Guid CitizenId { get; private set; } = Guid.NewGuid();
        
        [Column("location")]
        public string Location { get; private set; } = string.Empty;
    }
}