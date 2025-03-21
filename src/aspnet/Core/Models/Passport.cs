namespace Core.Models
{
    public class Passport
    {
        public Guid PassportId { get; set; } = Guid.NewGuid();
        public byte[] Number { get; set; } = null!;
        public byte[] Session { get; set; } = null!;
        public Guid CitizenId { get; set; }

        // Navigation property
        public Citizen Citizen { get; set; } = null!;

        private Passport(Guid passportId, byte[] number, byte[] session, Guid citizenId)
        {
            PassportId = passportId;
            Number = number;
            Session = session;
            CitizenId = citizenId;
        }

        public static (Passport? Passport, string Error) Create(Guid passportId, byte[] number, byte[] session, Guid citizenId)
        {
            string error = string.Empty;

            if (number == null || number.Length == 0)
            {
                error = "Number cannot be null or empty.";
            }

            if (session == null || session.Length == 0)
            {
                error = "Session cannot be null or empty.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var passport = new Passport(passportId, number!, session!, citizenId);
            return (passport, error);
        }
    }
}