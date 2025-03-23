namespace Core.Models
{
    public class Citizen
    {
        public Guid CitizenId { get; set; } = Guid.NewGuid();
        public string Location { get; set; } = null!;

        private Citizen(Guid citizenId, string location)
        {
            CitizenId = citizenId;
            Location = Location;
        }

        public static (Citizen? Citizen, string Error) Create(Guid citizenId, string name)
        {
            string error = ValidateInputs(name);

            var citizen = new Citizen(citizenId, name);
            return (citizen, error);
        }

        private static string ValidateInputs(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                return "Location cannot be empty.";
            }

            if (location.Length > 100)
            {
                return "Location cannot exceed 100 characters.";
            }

            return string.Empty;
        }
    }
}