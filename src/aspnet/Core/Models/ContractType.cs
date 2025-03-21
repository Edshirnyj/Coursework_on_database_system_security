namespace Core.Models
{
    public class ContractType
    {
        public Guid TypeId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        private ContractType(Guid typeId, string name)
        {
            TypeId = typeId;
            Name = name;
        }

        public static (ContractType? ContractType, string Error) Create(Guid typeId, string name)
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

            var contractType = new ContractType(typeId, name);
            return (contractType, error);
        }
    }
}