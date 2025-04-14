namespace Core.Models
{
    public class TypeContract
    {
        public Guid TypeContractId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;

        private TypeContract(Guid typeContractId, string name)
        {
            TypeContractId = typeContractId;
            Name = name;
        }

        public static (TypeContract? TypeContract, string Error) Create(Guid typeContractId, string name)
        {
            string error = ValidateInputs(name);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var typeContract = new TypeContract(typeContractId, name);
            return (typeContract, error);
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