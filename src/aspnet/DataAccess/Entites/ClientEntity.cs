namespace DataAccess.Entites
{
    public class ClientEntity
    {
        public Guid ClientId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = string.Empty;
        public byte[] Phone { get; set; } = Array.Empty<byte>();
        public byte[] Email { get; set; } = Array.Empty<byte>();
        public Guid PassportId { get; set; }
    }
}