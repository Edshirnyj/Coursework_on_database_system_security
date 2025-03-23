namespace Core.Models
{
    public class Mechanic
    {
        public Guid MechanicId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string Surname { get; private set; } = string.Empty;
        public string Patronymic { get; private set; } = string.Empty;
        public Guid PositionId { get; private set; } = Guid.NewGuid();

        public Position Position { get; private set; } = null!;

        private Mechanic(Guid mechanicId, string name, string surname, string patronymic, Guid positionId)
        {
            MechanicId = mechanicId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            PositionId = positionId;
        }

        public static (Mechanic? Mechanic, string Error) Create(Guid mechanicId, string name, string surname, string patronymic, Guid positionId)
        {
            string error = ValidateInputs(name, surname, patronymic, positionId);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var mechanic = new Mechanic(mechanicId, name, surname, patronymic, positionId);
            return (mechanic, error);
        }

        private static string ValidateInputs(string name, string surname, string patronymic, Guid positionId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Name cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                return "Surname cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(patronymic))
            {
                return "Patronymic cannot be empty.";
            }

            if (positionId == Guid.Empty)
            {
                return "PositionId cannot be empty.";
            }

            return string.Empty;
        }
    }
}