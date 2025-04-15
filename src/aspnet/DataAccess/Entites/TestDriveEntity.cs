using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    [Table("test_drives")]
    public class TestDriveEntity
    {
        [Column("test_id")]
        public Guid TestId { get; private set; } = Guid.NewGuid();
        
        [Column("client_id")]
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        
        [Column("auto_id")]
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        
        [Column("date_of_test")]
        public DateTime DateOfTest { get; private set; } = DateTime.Now;
        
        [Column("fine_points")]
        public string FinePoints { get; private set; } = string.Empty;

    }
}
