namespace Core.Models
{
    public class Citizen
    {
        public Guid CitizenId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public Guid LocalityId { get; set; }

        // Navigation property
        public Locality Locality { get; set; } = null!;

        private Citizen(Guid citizenId, string name, Guid localityId)
        {
            CitizenId = citizenId;
            Name = name;
            LocalityId = localityId;
        }

        public static (Citizen? Citizen, string Error) Create(Guid citizenId, string name, Guid localityId)
        {
            string error = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Name cannot be null or empty.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var citizen = new Citizen(citizenId, name, localityId);
            return (citizen, error);
        }
    }
}