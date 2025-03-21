namespace Core.Models
{
    public class Status
    {
        public Guid StatusId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        private Status(Guid statusId, string name)
        {
            StatusId = statusId;
            Name = name;
        }

        public static (Status? Status, string Error) Create(Guid statusId, string name)
        {
            string error = string.Empty;
            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Name cannot be empty.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }
            
            var status = new Status(statusId, name);
            return (status, error);
        }
    }
}