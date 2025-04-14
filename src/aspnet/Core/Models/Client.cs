namespace Core.Models
{
    public class Client
    {
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string Surname { get; private set; } = string.Empty;
        public string Patronymic { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; } = DateTime.Now; 
        public string City { get; private set; } = string.Empty;
        public Guid PassportId { get; private set; } = Guid.NewGuid();

        public Passport Passport { get; private set; } = null!;

        private Client(Guid clientId, string name, string surname, string patronymic, DateTime birthDate, string city, Guid passportId)
        {
            ClientId = clientId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            City = city;
            PassportId = passportId;
        }

        public static (Client? Client, string Error) Create(Guid clientId, string name, string surname, string patronymic, DateTime birthDate, string city, Guid passportId)
        {
            string error = ValidateInputs(name, surname, patronymic, birthDate, city);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var client = new Client(clientId, name, surname, patronymic, birthDate, city, passportId);
            return (client, error);
        }

        private static string ValidateInputs(string name, string surname, string patronymic, DateTime birthDate, string city)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Name cannot be empty.";

            if (name.Length > 50)
                return "Name cannot exceed 50 characters.";

            if (string.IsNullOrWhiteSpace(surname))
                return "Surname cannot be empty.";

            if (surname.Length > 50)
                return "Surname cannot exceed 50 characters.";

            if (string.IsNullOrWhiteSpace(patronymic))
                return "Patronymic cannot be empty.";

            if (patronymic.Length > 50)
                return "Patronymic cannot exceed 50 characters.";

            if (birthDate > DateTime.Now)
                return "Birth date cannot be in the future.";

            if (string.IsNullOrWhiteSpace(city))
                return "City cannot be empty.";

            if (city.Length > 100)
                return "City cannot exceed 100 characters.";

            return string.Empty;
        }
    }
}