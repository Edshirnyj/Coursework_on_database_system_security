namespace Core.Models
{
    public class ProfileMechanicModel
    {
        public Guid ProfileId { get; set; }
        public Guid MechanicId { get; set; }
        public byte[]? Email { get; set; }
        public byte[]? Phone { get; set; }
        public string? Username { get; set; }
        public byte[]? Password { get; set; }
        public byte[]? SecretKey { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        private ProfileMechanicModel(Guid profileId, Guid mechanicId, byte[]? email, byte[]? phone, string? username, byte[]? password, byte[]? secretKey, DateTime createdAt, DateTime updatedAt)
        {
            ProfileId = profileId;
            MechanicId = mechanicId;
            Email = email;
            Phone = phone;
            Username = username;
            Password = password;
            SecretKey = secretKey;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static (ProfileMechanicModel ProfileMechanicModel, string Error) Create(Guid profileId, Guid mechanicId, byte[]? email, byte[]? phone, string? username, byte[]? password, byte[]? secretKey, DateTime createdAt, DateTime updatedAt)
        {
            string? error = ValidateInputs(mechanicId, username);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var profileMechanicModel = new ProfileMechanicModel(profileId, mechanicId, email, phone, username, password, secretKey, createdAt, updatedAt);
            return (profileMechanicModel, string.Empty);
        }

        private static string? ValidateInputs(Guid mechanicId, string? username)
        {
            if (mechanicId == Guid.Empty)
                return "Mechanic ID cannot be empty.";

            if (string.IsNullOrWhiteSpace(username))
                return "Username cannot be empty.";

            return string.Empty;
        }
    }
}