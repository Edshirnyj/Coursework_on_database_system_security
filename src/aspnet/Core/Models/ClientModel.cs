namespace Core.Models
{
    public class ClientModel
    {
        public Guid ClientId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string? City { get; set; }
        public Guid PassportId { get; set; }

        private ClientModel(Guid clientId, string? name, string? surname, string? patronymic, DateTime birthDate, string? city, Guid passportId)
        {
            ClientId = clientId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            City = city;
            PassportId = passportId;
        }

        public static (ClientModel ClientModel, string Error) Create(Guid clientId, string? name, string? surname, string? patronymic, DateTime birthDate, string? city, Guid passportId)
        {
            string? error = ValidateInputs(name, surname, patronymic, birthDate, city, passportId);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var clientModel = new ClientModel(clientId, name, surname, patronymic, birthDate, city, passportId);
            return (clientModel, string.Empty);
        }

        private static string? ValidateInputs(string? name, string? surname, string? patronymic, DateTime birthDate, string? city, Guid passportId)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Name cannot be empty.";

            if (string.IsNullOrWhiteSpace(surname))
                return "Surname cannot be empty.";

            if (string.IsNullOrWhiteSpace(patronymic))
                return "Patronymic cannot be empty.";

            if (birthDate > DateTime.UtcNow)
                return "Birth date cannot be in the future.";

            if (string.IsNullOrWhiteSpace(city))
                return "City cannot be empty.";

            if (passportId == Guid.Empty)
                return "Passport ID cannot be empty.";

            return string.Empty;
        }
    }
}