namespace Core.Models
{
    public class Position
    {
        public Guid PositionId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;

        private Position(Guid positionId, string name)
        {
            PositionId = positionId;
            Name = name;
        }

        public static (Position? Position, string Error) Create(Guid positionId, string name)
        {
            string error = ValidateInputs(name);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var position = new Position(positionId, name);
            return (position, error);
        }

        private static string ValidateInputs(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Name cannot be empty.";

            if (name.Length > 50)
                return "Name cannot exceed 50 characters.";

            return string.Empty;
        }
    }
}