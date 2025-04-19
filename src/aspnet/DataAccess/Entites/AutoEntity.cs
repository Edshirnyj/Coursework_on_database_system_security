using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    [Table("autos")]
    public class AutoEntity
    {
        [Column("auto_id")]
        public Guid AutoId { get; private set; } = Guid.NewGuid();

        [Column("model_id")]
        public Guid ModelId { get; private set; } = Guid.NewGuid();

        [Column("brand_id")]
        public Guid BrandId { get; private set; } = Guid.NewGuid();

        [Column("year_of_issue")]
        public int YearOfIssue { get; private set; } = 0;

        [Column("color")]
        public string Color { get; private set; } = string.Empty;

        [Column("vin")]
        public string Vin { get; private set; } = string.Empty;

        [Column("photo_path")]
        public string PhotoPath { get; private set; } = string.Empty;

        [Column("mileage")]
        public decimal Mileage { get; private set; } = 0.0m;

        [Column("status_id")]
        public Guid StatusId { get; private set; } = Guid.NewGuid();


        [ForeignKey(nameof(ModelId))]
        public ModelEntity? Models { get; set; }

        [ForeignKey(nameof(BrandId))]
        public BrandEntity? Brands { get; set; }

        [ForeignKey(nameof(StatusId))]
        public StatusEntity? Statuses { get; set; }

    }
}