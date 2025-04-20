namespace Core.Models
{
    public class PassportModel
    {
        public Guid PassportId { get; set; }
        public byte[]? Number { get; set; }
        public byte[]? Session { get; set; }
        public Guid CitizenId { get; set; }        

        private PassportModel(Guid passportId, byte[]? number, byte[]? session, Guid citizenId)
        {
            PassportId = passportId;
            Number = number;
            Session = session;
            CitizenId = citizenId;
        }

        public static (PassportModel PassportModel, string Error) Create(Guid passportId, byte[]? number, byte[]? session, Guid citizenId)
        {
            string? error = ValidateInputs(number, session, citizenId);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var passportModel = new PassportModel(passportId, number, session, citizenId);
            return (passportModel, string.Empty);
        }

        private static string? ValidateInputs(byte[]? number, byte[]? session, Guid citizenId)
        {
            if (number == null || number.Length == 0)
                return "Passport number cannot be empty.";

            if (session == null || session.Length == 0)
                return "Passport session cannot be empty.";

            if (citizenId == Guid.Empty)
                return "Citizen ID cannot be empty.";

            return string.Empty;
        }
    }
}