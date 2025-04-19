using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("clients")]
    [PrimaryKey(nameof(ClientId))]
    public class ClientEntity
    {
        [Column("client_id")]
        public Guid ClientId { get; private set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; private set; } = string.Empty;

        [Column("surname")]
        public string Surname { get; private set; } = string.Empty;

        [Column("patronymic")]
        public string Patronymic { get; private set; } = string.Empty;

        [Column("birth_date")]
        public DateTime BirthDate { get; private set; } = DateTime.UtcNow;

        [Column("city")]
        public string City { get; private set; } = string.Empty;

        [Column("passport_id")]
        public Guid PassportId { get; private set; } = Guid.NewGuid();


        [ForeignKey(nameof(PassportId))]
        public PassportEntity? Passports { get; set; }
    }
}