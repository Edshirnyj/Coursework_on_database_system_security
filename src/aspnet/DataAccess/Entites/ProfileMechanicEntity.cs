namespace DataAccess.Entites
{
    public class ProfileMechanicEntity
    {
        public Guid ProfileId { get; private set; } = Guid.NewGuid();
        public Guid MechanicId { get; private set; } = Guid.NewGuid();
        public string Email { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public byte[] Username { get; private set; } = [];
        public byte[] Password { get; private set; } = [];
        public byte[] SecretKey { get; private set; } = [];

    }
}