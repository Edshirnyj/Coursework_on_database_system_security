namespace Core.Models
{
    public class Continent
    {
        public Guid ContinentId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;

        private Continent(Guid continentId, string name)
        {
            ContinentId = continentId;
            Name = name;
        }

        public static (Continent? Continent, string Error) Create(Guid continentId, string name)
        {
            string error = ValidateInputs(name);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var continent = new Continent(continentId, name);
            return (continent, string.Empty);
        }

        private static string ValidateInputs(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Name cannot be empty.";
            }

            if (name.Length > 100)
            {
                return "Name cannot exceed 100 characters.";
            }

            return string.Empty;
        }
    }
}