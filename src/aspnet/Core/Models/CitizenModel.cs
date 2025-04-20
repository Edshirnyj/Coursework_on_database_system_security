namespace Core.Models
{
    public class CitizenModel
    {
        public Guid CitizenId { get; set; }
        public string? Location { get; set; }

        private CitizenModel(Guid citizenId, string? location)
        {
            CitizenId = citizenId;
            Location = location;
        }

        public static (CitizenModel CitizenModel, string Error) Create(Guid citizenId, string? location)
        {
            string? error = ValidateInputs(location);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var citizenModel = new CitizenModel(citizenId, location);
            return (citizenModel, string.Empty);
        }

        private static string? ValidateInputs(string? location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return "Location cannot be empty.";

            return string.Empty;
        }
    }
}