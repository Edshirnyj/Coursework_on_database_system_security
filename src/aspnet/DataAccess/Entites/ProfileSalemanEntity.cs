namespace DataAccess.Entites
{
    public class ProfileSalemanEntity
    {
        public Guid ProfileId { get; private set; } = Guid.NewGuid();
        public Guid SalemanId { get; private set; } = Guid.NewGuid();
        public string EMail { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string Username { get; private set; } = string.Empty;
        public byte[] Password { get; private set; } = [];
        public byte[] SecretKey { get; private set; } = [];
    }
}