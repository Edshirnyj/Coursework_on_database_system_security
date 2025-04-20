namespace Core.Models
{
    public class PositionModel
    {
        public Guid PositionId { get; set; }
        public string? Name { get; set; }

        private PositionModel(Guid positionId, string? name)
        {
            PositionId = positionId;
            Name = name;
        }

        public static (PositionModel PositionModel, string Error) Create(Guid positionId, string? name)
        {
            string? error = ValidateInputs(name);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var positionModel = new PositionModel(positionId, name);
            return (positionModel, string.Empty);
        }

        private static string? ValidateInputs(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Position name cannot be empty.";

            return string.Empty;
        }        
    }
}