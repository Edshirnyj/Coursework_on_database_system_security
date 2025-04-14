namespace Core.Models
{
    public class Saleman
    {
        public Guid SalemanId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string Surname { get; private set; } = string.Empty;
        public string Patronymic { get; private set; } = string.Empty;
        public Guid PositionId { get; private set; } = Guid.NewGuid();

        public Position Position { get; private set; } = null!;

        private Saleman(Guid salemanId, string name, string surname, string patronymic, Guid positionId)
        {
            SalemanId = salemanId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            PositionId = positionId;
        }

        public static (Saleman? Saleman, string Error) Create(Guid salemanId, string name, string surname, 
                                                              string patronymic, Guid positionId)
        {
            string error = ValidateInputs(name, surname, patronymic);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var saleman = new Saleman(salemanId, name, surname, patronymic, positionId);
            return (saleman, error);
        }

        private static string ValidateInputs(string name, string surname, string patronymic)
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

            return string.Empty;
        }
    }
}