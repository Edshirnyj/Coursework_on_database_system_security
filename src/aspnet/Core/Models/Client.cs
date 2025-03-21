namespace Core.Models
{
    public class Client
    {
        public Guid ClientId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = string.Empty;
        public byte[] Phone { get; set; } = Array.Empty<byte>();
        public byte[] Email { get; set; } = Array.Empty<byte>();
        public Guid PassportId { get; set; }

        public Passport Passport { get; set; } = null!;

        private Client(Guid clientId, string firstName, string secondName, string thirdName, byte[] phone, byte[] email, Guid passportId)
        {
            ClientId = clientId;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            Phone = phone;
            Email = email;
            PassportId = passportId;
        }

        public static (Client? Client, string Error) Create(Guid clientId, string firstName, string secondName, string thirdName, byte[] phone, byte[] email, Guid passportId)
        {
            string error = string.Empty;

            if (string.IsNullOrWhiteSpace(firstName))
            {
                error = "First name cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(secondName))
            {
                error = "Second name cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(thirdName))
            {
                error = "Third name cannot be empty.";
            }

            if (phone == null || phone.Length == 0)
            {
                error = "Phone cannot be empty.";
            }

            if (email == null || email.Length == 0)
            {
                error = "Email cannot be empty.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var client = new Client(clientId, firstName, secondName, thirdName, phone!, email!, passportId);
            return (client, error);
        }
    }
}