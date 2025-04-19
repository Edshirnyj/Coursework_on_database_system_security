using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    [Table("profile_salesmans")]
    public class ProfileSalesmanEntity
    {
        [Column("profile_id")]
        public Guid ProfileId { get; private set; } = Guid.NewGuid();
        
        [Column("salesman_id")]
        public Guid SalesmanId { get; private set; } = Guid.NewGuid();
        
        [Column("e_mail")]
        public string EMail { get; private set; } = string.Empty;
        
        [Column("phone")]
        public string Phone { get; private set; } = string.Empty;
        
        [Column("username")]
        public string Username { get; private set; } = string.Empty;
        
        [Column("password")]
        public byte[] Password { get; private set; } = [];
        
        [Column("secret_key")]
        public byte[] SecretKey { get; private set; } = [];

        [Column("created_at")]
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;


        [ForeignKey("salesman_id")]
        public SalesmanEntity Salesman { get; private set; } = new SalesmanEntity();
    }
}