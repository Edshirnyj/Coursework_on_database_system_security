namespace Core.Models
{
    public class ContractType
    {
        public Guid TypeId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;

        private ContractType(Guid typeId, string name)
        {
            TypeId = typeId;
            Name = name.Trim();
        }

        public static (ContractType? ContractType, string Error) Create(Guid typeId, string name)
        {
            string error = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Name cannot be empty.";
            }
            else if (name.Length > 255)
            {
                error = "Name cannot exceed 255 characters.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var contractType = new ContractType(typeId, name);
            return (contractType, error);
        }

        private static string ValidateInputs(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Name cannot be empty.";
            }

            if (name.Length > 255)
            {
                return "Name cannot exceed 255 characters.";
            }

            return string.Empty;
        }
    }
}