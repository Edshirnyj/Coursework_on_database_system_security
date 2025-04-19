using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("profile_salesmans")]
    [PrimaryKey(nameof(ProfileId))]
    public class ProfileSalesmanEntity
    {
       [Column("profile_id")]
       public Guid ProfileId { get; private set; } = Guid.NewGuid();

        [Column("salesman_id")]
        public Guid SalesmanId { get; private set; } = Guid.NewGuid();

        [Column("e_mail")]
        public byte[] Email { get; private set; } = [];

        [Column("phone")]
        public byte[] Phone { get; private set; } = [];

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


        [ForeignKey(nameof(SalesmanId))]
        public SalesmanEntity? Salesmans { get; set; }
    }
}