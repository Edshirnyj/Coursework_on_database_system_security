namespace Core.Models
{
    public class Status
    {
        public Guid StatusId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;

        private Status(Guid statusId, string name)
        {
            StatusId = statusId;
            Name = name.Trim();
        }

        public static (Status? Status, string Error) Create(Guid statusId, string name)
        {
            string error = ValidateInputs(name);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var sanitizedStatusId = statusId == Guid.Empty ? Guid.NewGuid() : statusId;
            var status = new Status(sanitizedStatusId, name);
            return (status, error);
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