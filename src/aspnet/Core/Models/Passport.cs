namespace Core.Models
{
    public class Passport
    {
        public Guid PassportId { get; private set; } = Guid.NewGuid();
        public byte[] Number { get; private set; } = null!;
        public byte[] Session { get; private set; } = null!;
        public Guid CitizenId { get; private set; } = Guid.Empty;

        public Citizen Citizen { get; private set; } = null!;

        private Passport(Guid passportId, byte[] number, byte[] session, Guid citizenId)
        {
            PassportId = passportId;
            Number = number;
            Session = session;
            CitizenId = citizenId;
        }

        public static (Passport? Passport, string Error) Create(Guid passportId, byte[] number, byte[] session, Guid citizenId)
        {
            string error = ValidateInputs(number, session, citizenId);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var passport = new Passport(passportId, number, session, citizenId);
            return (passport, error);
        }

        private static string ValidateInputs(byte[] number, byte[] session, Guid citizenId)
        {
            if (number == null || number.Length == 0)
                return "Number cannot be empty.";

            if (session == null || session.Length == 0)
                return "Session cannot be empty.";

            if (citizenId == Guid.Empty)
                return "Citizen ID cannot be empty.";

            return string.Empty;
        }
    }
}