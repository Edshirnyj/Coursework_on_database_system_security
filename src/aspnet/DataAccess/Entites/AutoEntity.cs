namespace DataAccess.Entites
{
    public class AutoEntity
    {
        public Guid AutoId { get; set; } = Guid.NewGuid();
        public Guid ModelId { get; set; }
        public int Year { get; set; }
        public byte[] Vin { get; set; } = [];
        public int Mileage { get; set; }
        public Guid? StatusId { get; set; }
    }
}