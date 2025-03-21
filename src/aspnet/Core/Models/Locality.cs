namespace Core.Models
{
    public class Locality
    {
        public Guid LocalityId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;

        private Locality(Guid localityId, string name)
        {
            LocalityId = localityId;
            Name = name;
        }

        public static (Locality? Locality, string Error) Create(Guid localityId, string name)
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

            var locality = new Locality(localityId, name);
            return (locality, error);
        }
    }
}