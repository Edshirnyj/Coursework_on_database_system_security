namespace DataAccess.Entites
{
    public class ProfileClientEntity
    {
        public Guid ProfileId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public string Email { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string Username { get; private set; } = string.Empty;
        public byte[] Password { get; private set; } = [];
        public byte[] SecretKey { get; private set; } = [];
    }
}