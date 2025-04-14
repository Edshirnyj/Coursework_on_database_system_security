namespace Core.Models
{
    public class Citizen
    {
        public Guid CitizenId { get; private set; } = Guid.NewGuid();
        public string Location { get; private set; } = string.Empty;

        private Citizen(Guid citizenId, string location)
        {
            CitizenId = citizenId;
            Location = location;
        }

        public static (Citizen? Citizen, string Error) Create(Guid citizenId, string location)
        {
            string error = ValidateInputs(location);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var citizen = new Citizen(citizenId, location);
            return (citizen, error);
        }

        private static string ValidateInputs(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return "Location cannot be empty.";

            if (location.Length > 50)
                return "Location cannot exceed 50 characters.";

            return string.Empty;
        }
    }
}