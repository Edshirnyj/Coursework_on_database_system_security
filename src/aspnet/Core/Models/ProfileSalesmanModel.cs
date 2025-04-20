namespace Core.Models
{
    public class ProfileSalesmanModel
    {
        public Guid ProfileId { get; set; }
        public Guid SalesmanId { get; set; }
        public byte[]? Email { get; set; }
        public byte[]? Phone { get; set; }
        public string? Username { get; set; }
        public byte[]? Password { get; set; }
        public byte[]? SecretKey { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        private ProfileSalesmanModel(Guid profileId, Guid salesmanId, byte[]? email, byte[]? phone, string? username, byte[]? password, byte[]? secretKey, DateTime createdAt, DateTime updatedAt)
        {
            ProfileId = profileId;
            SalesmanId = salesmanId;
            Email = email;
            Phone = phone;
            Username = username;
            Password = password;
            SecretKey = secretKey;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static (ProfileSalesmanModel ProfileSalesmanModel, string Error) Create(Guid profileId, Guid salesmanId, byte[]? email, byte[]? phone, string? username, byte[]? password, byte[]? secretKey, DateTime createdAt, DateTime updatedAt)
        {
            string? error = ValidateInputs(salesmanId, username);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var profileSalesmanModel = new ProfileSalesmanModel(profileId, salesmanId, email, phone, username, password, secretKey, createdAt, updatedAt);
            return (profileSalesmanModel, string.Empty);
        }

        private static string? ValidateInputs(Guid salesmanId, string? username)
        {
            if (salesmanId == Guid.Empty)
                return "Salesman ID cannot be empty.";

            if (string.IsNullOrWhiteSpace(username))
                return "Username cannot be empty.";

            return string.Empty;
        }        
    }
}