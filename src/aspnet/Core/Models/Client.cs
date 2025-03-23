namespace Core.Models
{
    using System.Text.RegularExpressions;

    public class Client
    {
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string Surname { get; private set; } = string.Empty;
        public string Patronymic { get; private set; } = string.Empty;
        public DateOnly BirthDate { get; private set; }
        public string City { get; private set; } = string.Empty;
        public Guid PassportId { get; private set; }

        public Passport Passport { get; private set; } = null!;

        private Client(Guid clientId, string name, string surname, string patronymic, DateOnly birthDate, string city, Guid passportId)
        {
            ClientId = clientId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            City = city;
            PassportId = passportId;
        }

        public static (Client? Client, string Error) Create(Guid clientId, string name, string surname, string patronymic, DateOnly birthDate, string city, Guid passportId)
        {
            string error = ValidateInputs(name, surname, patronymic, city);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var client = new Client(clientId, name.Trim(), surname.Trim(), patronymic.Trim(), birthDate, city.Trim(), passportId);
            return (client, error);
        }

        private static string ValidateInputs(string firstName, string secondName, string thirdName, string city)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return "First name cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(secondName))
            {
                return "Second name cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(thirdName))
            {
                return "Third name cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                return "City cannot be empty.";
            }

            if (firstName.Length > 50)
            {
                return "First name cannot exceed 50 characters.";
            }

            if (secondName.Length > 50)
            {
                return "Second name cannot exceed 50 characters.";
            }

            if (thirdName.Length > 50)
            {
                return "Third name cannot exceed 50 characters.";
            }

            if (city.Length > 100)
            {
                return "City cannot exceed 100 characters.";
            }

            if (!Regex.IsMatch(firstName, "^[а-яА-Я-]+$"))
            {
                return "First name contains invalid characters. Only Russian letters and hyphens are allowed.";
            }

            if (!Regex.IsMatch(secondName, "^[а-яА-Я-]+$"))
            {
                return "Second name contains invalid characters. Only Russian letters and hyphens are allowed.";
            }

            if (!Regex.IsMatch(thirdName, "^[а-яА-Я-]+$"))
            {
                return "Third name contains invalid characters. Only Russian letters and hyphens are allowed.";
            }

            if (!Regex.IsMatch(city, "^[а-яА-Я-]+$"))
            {
                return "City contains invalid characters. Only Russian letters and hyphens are allowed.";
            }

            return string.Empty;
        }
    }
}