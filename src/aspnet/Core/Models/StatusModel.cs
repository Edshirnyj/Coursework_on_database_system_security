namespace Core.Models
{
    public class StatusModel
    {
        public Guid StatusId { get; set; }
        public string? Name { get; set; }

        private StatusModel(Guid statusId, string? name)
        {
            StatusId = statusId;
            Name = name;
        }

        public static (StatusModel StatusModel, string Error) Create(Guid statusId, string? name)
        {
            string? error = ValidateInputs(name);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var statusModel = new StatusModel(statusId, name);
            return (statusModel, string.Empty);
        }

        private static string? ValidateInputs(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Status name cannot be empty.";

            return string.Empty;
        }        
    }
}