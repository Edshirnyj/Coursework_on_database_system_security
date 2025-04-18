using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("profile_clients")]
    [PrimaryKey(nameof(ProfileId))]
    public class ProfileClientEntity
    {
        [Column("profile_id")]
        public Guid ProfileId { get; private set; } = Guid.NewGuid();

        [Column("client_id")]
        public Guid ClientId { get; private set; } = Guid.NewGuid();

        [Column("e_mail")]
        public string Email { get; private set; } = string.Empty;

        [Column("phone")]
        public string Phone { get; private set; } = string.Empty;

        [Column("username")]
        public string Username { get; private set; } = string.Empty;

        [Column("password")]
        public string Password { get; private set; } = string.Empty;

        [Column("secret_key")]
        public string SecretKey { get; private set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        [ForeignKey(nameof(ClientId))]
        public ClientEntity? Clients { get; set; }
    }
}