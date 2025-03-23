namespace Core.Models
{
    public class Passport
    {
        public Guid PassportId { get; private set; } = Guid.NewGuid();
        public byte[] Number { get; private set; } = null!;
        public byte[] Session { get; private set; } = null!;
        public Guid CitizenId { get; private set; }

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
            string error = ValidateInputs(number, session);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var sanitizedNumber = (byte[])number!.Clone();
            var sanitizedSession = (byte[])session!.Clone();

            var passport = new Passport(passportId, sanitizedNumber, sanitizedSession, citizenId);
            return (passport, error);
        }

        private static string ValidateInputs(byte[] number, byte[] session)
        {
            if (number == null || number.Length == 0)
            {
                return "Number cannot be null or empty.";
            }

            if (session == null || session.Length == 0)
            {
                return "Session cannot be null or empty.";
            }

            return string.Empty;
        }
    }
}