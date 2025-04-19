using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entites
{
    [Table("passports")]
    [PrimaryKey(nameof(PassportId))]
    public class PassportEntity
    {
        [Column("passport_id")]
        public Guid PassportId { get; private set; } = Guid.NewGuid();

        [Column("number")]
        public byte[] Number { get; private set; } = [];

        [Column("session")]
        public byte[] Session { get; private set; } = [];

        [Column("citizen_id")]
        public Guid CitizenId { get; private set; } = Guid.NewGuid();


        [ForeignKey(nameof(CitizenId))]
        public CitizenEntity? Citizens { get; set; } 
    }
}