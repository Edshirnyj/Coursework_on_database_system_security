namespace DataAccess.Entites
{
    public class AutoEntity
    {
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        public Guid ModelId { get; private set; }
        public int Year { get; private set; }
        public string Color { get; private set; } = string.Empty;
        public byte[] Vin { get; private set; } = Array.Empty<byte>();
        public int Mileage { get; private set; }
        public Guid? StatusId { get; private set; }

    }
}