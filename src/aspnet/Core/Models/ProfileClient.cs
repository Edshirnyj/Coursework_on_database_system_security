using System.Text.RegularExpressions;

namespace Core.Models
{
    public class ProfileClient
    {
        public Guid ProfileId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public string Email { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string Username { get; private set; } = string.Empty;
        public byte[] Password { get; private set; } = [];
        public byte[] SecretKey { get; private set; } = [];

        public Client Client { get; private set; } = null!;

        private ProfileClient(Guid profileId, Guid clientId, string email, string phone, 
                              string username, byte[] password, byte[] secretKey)
        {
            ProfileId = profileId;
            ClientId = clientId;
            Email = email;
            Phone = phone;
            Username = username;
            Password = password;
            SecretKey = secretKey;
        }

        public static (ProfileClient? ProfileClient, string Error) Create(Guid profileId, Guid clientId, 
                                                                          string email, string phone, 
                                                                          string username, byte[] password, 
                                                                          byte[] secretKey)
        {
            string error = ValidateInputs(email, phone, username, password, secretKey);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var profileClient = new ProfileClient(profileId, clientId, email, phone, username, password, secretKey);
            return (profileClient, error);
        }

        private static string ValidateInputs(string email, string phone, string username, 
                                             byte[] password, byte[] secretKey)
        {
            if (string.IsNullOrWhiteSpace(email)) 
                return "Email cannot be empty.";
            
            if (email.Length > 100) 
                return "Email cannot exceed 100 characters.";
            
            if (string.IsNullOrWhiteSpace(phone)) 
                return "Phone cannot be empty.";

            if (phone.Length > 20) 
                return "Phone cannot exceed 20 characters.";

            if (!IsValidEmail(email))
                return "Invalid email format.";

            return string.Empty;
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}