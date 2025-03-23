namespace Core.Models
{
    public class ProfileSaleman
    {
        public Guid ProfileId { get; private set; } = Guid.NewGuid();
        public Guid SalemanId { get; private set; } = Guid.NewGuid();
        public string Email { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public byte[] Username { get; private set; } = [];
        public byte[] Password { get; private set; } = [];
        public byte[] SecretKey { get; private set; } = [];

        public Saleman Saleman { get; private set; } = null!;

        private ProfileSaleman(Guid profileId, Guid salemanId, string email, string phone, byte[] username, byte[] password, byte[] secretKey)
        {
            ProfileId = profileId;
            SalemanId = salemanId;
            Email = email;
            Phone = phone;
            Username = username;
            Password = password;
            SecretKey = secretKey;
        }

        public static (ProfileSaleman? ProfileSaleman, string Error) Create(Guid profileId, Guid salemanId, string email, string phone, byte[] username, byte[] password, byte[] secretKey)
        {
            string error = ValidateInputs(email, phone, username, password, secretKey);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var profileSaleman = new ProfileSaleman(profileId, salemanId, email, phone, username, password, secretKey);
            return (profileSaleman, error);
        }

        private static string ValidateInputs(string email, string phone, byte[] username, byte[] password, byte[] secretKey)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return "Email cannot be empty.";
            }

            if (email.Length > 100)
            {
                return "Email cannot exceed 100 characters.";
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                return "Phone cannot be empty.";
            }

            if (phone.Length > 20)
            {
                return "Phone cannot exceed 20 characters.";
            }

            return string.Empty;
        }
    }
}