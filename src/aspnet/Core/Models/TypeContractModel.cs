namespace Core.Models
{
    public class TypeContractModel
    {
        public Guid TypeContractId { get; set; }
        public string? Name { get; set; }

        private TypeContractModel(Guid typeContractId, string? name)
        {
            TypeContractId = typeContractId;
            Name = name;
        }

        public static (TypeContractModel TypeContractModel, string Error) Create(Guid typeContractId, string? name)
        {
            string? error = ValidateInputs(name);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var typeContractModel = new TypeContractModel(typeContractId, name);
            return (typeContractModel, string.Empty);
        }

        private static string? ValidateInputs(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Type contract name cannot be empty.";

            return string.Empty;
        }        
    }
}