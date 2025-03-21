namespace DataAccess.Entites
{
    public class PassportEntity
    {
        public Guid PassportId { get; set; } = Guid.NewGuid();
        public byte[] Number { get; set; } = null!;
        public byte[] Session { get; set; } = null!;
        public Guid CitizenId { get; set; }
    }
}