namespace Core.Models
{
    public class Continent
    {
        public Guid ContinentId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        private Continent(Guid continentId, string name)
        {
            ContinentId = continentId;
            Name = name;
        }

        public static (Continent? Continent, string Error) Create(Guid continentId, string name)
        {
            string error = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Name cannot be empty.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var continent = new Continent(continentId, name);
            return (continent, error);
        }
    }
}