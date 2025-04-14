namespace Core.Models
{
    public class HistoryTransform
    {
        public Guid TransformId { get; private set; } = Guid.NewGuid();
        public Guid SalemanId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public Guid ContractId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;

        public Client Client { get; set; } = null!;
        public Saleman Saleman { get; set; } = null!;
        public Contract Contract { get; set; } = null!;

        private HistoryTransform(Guid transformId, Guid salemanId, Guid clientId, Guid contractId, string name)
        {
            TransformId = transformId;
            SalemanId = salemanId;
            ClientId = clientId;
            ContractId = contractId;
            Name = name;
        }

        public static (HistoryTransform? HistoryTransform, string Error) Create(Guid transformId, Guid salemanId, Guid clientId, Guid contractId, string name)
        {
            string error = ValidateInputs(name);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var historyTransform = new HistoryTransform(transformId, salemanId, clientId, contractId, name);
            return (historyTransform, error);
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