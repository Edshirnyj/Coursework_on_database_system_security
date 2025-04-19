using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    [Table("passports")]
    public class PassportEntity
    {
        [Column("passport_id")]
        public Guid PassportId { get; private set; } = Guid.NewGuid();
        
        [Column("number")]
        public byte[] Number { get; private set; } = null!;
        
        [Column("session")]
        public byte[] Session { get; private set; } = null!;
        
        [Column("citizen_id")]
        public Guid CitizenId { get; private set; } = Guid.Empty;

        [ForeignKey("citizen_id")]
        public CitizenEntity Citizen { get; private set; } = new CitizenEntity();
    }
}