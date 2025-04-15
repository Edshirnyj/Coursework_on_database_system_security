namespace DataAccess.Entites
{
    public class AutoEntity
    {
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        public Guid ModelId { get; private set; } = Guid.NewGuid();
        public Guid BrandId { get; private set; } = Guid.NewGuid();
        public int Year { get; private set; } = DateTime.Now.Year;
        public string Color { get; private set; } = string.Empty;
        public byte[] Vin { get; private set; } = [];
        public string PhotoPath { get; private set; } = string.Empty;
        public int Mileage { get; private set; } = 0;
        public Guid? StatusId { get; private set; } = null;
    }
}