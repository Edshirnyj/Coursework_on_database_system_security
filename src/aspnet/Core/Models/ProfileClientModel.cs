namespace Core.Models
{
    public class ProfileClientModel
    {
        public Guid ProfileId { get; set; }
        public Guid ClientId { get; set; }
        public byte[]? Email { get; set; }
        public byte[]? Phone { get; set; }
        public string? Username { get; set; }
        public byte[]? Password { get; set; }
        public byte[]? SecretKey { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        private ProfileClientModel(Guid profileId, Guid clientId, byte[]? email, byte[]? phone, string? username, byte[]? password, byte[]? secretKey, DateTime createdAt, DateTime updatedAt)
        {
            ProfileId = profileId;
            ClientId = clientId;
            Email = email;
            Phone = phone;
            Username = username;
            Password = password;
            SecretKey = secretKey;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static (ProfileClientModel ProfileClientModel, string Error) Create(Guid profileId, Guid clientId, byte[]? email, byte[]? phone, string? username, byte[]? password, byte[]? secretKey, DateTime createdAt, DateTime updatedAt)
        {
            string? error = ValidateInputs(clientId, username);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var profileClientModel = new ProfileClientModel(profileId, clientId, email, phone, username, password, secretKey, createdAt, updatedAt);
            return (profileClientModel, string.Empty);
        }

        private static string? ValidateInputs(Guid clientId, string? username)
        {
            if (clientId == Guid.Empty)
                return "Client ID cannot be empty.";

            if (string.IsNullOrWhiteSpace(username))
                return "Username cannot be empty.";

            return string.Empty;
        }


    }
}