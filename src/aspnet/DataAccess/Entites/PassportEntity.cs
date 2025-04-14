namespace DataAccess.Entites
{
    public class PassportEntity
    {
        public Guid PassportId { get; private set; } = Guid.NewGuid();
        public byte[] Number { get; private set; } = null!;
        public byte[] Session { get; private set; } = null!;
        public Guid CitizenId { get; private set; } = Guid.Empty;
    }
}