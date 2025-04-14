namespace Core.Models
{
    public class Status
    {
        public Guid StatusId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;

        private Status(Guid statusId, string name)
        {
            StatusId = statusId;
            Name = name;
        }

        public static (Status? Status, string Error) Create(Guid statusId, string name)
        {
            string error = ValidateInputs(name);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var status = new Status(statusId, name);
            return (status, error);
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