namespace Core.Models
{
    public class HistoryTransform
    {
        public Guid TransformId { get; set; } = Guid.NewGuid();
        public Guid ClientId { get; set; }
        public Guid SalemanId { get; set; }
        public Guid ContractId { get; set; }
        public string Name { get; set; } = string.Empty;

        public Client Client { get; set; } = null!;
        public Saleman Saleman { get; set; } = null!;
        public Contract Contract { get; set; } = null!;

        private HistoryTransform(Guid transformId, Guid clientId, Guid salemanId, Guid contractId, string name)
        {
            TransformId = transformId;
            ClientId = clientId;
            SalemanId = salemanId;
            ContractId = contractId;
            Name = name;
        }

        public static (HistoryTransform? HistoryTransform, string Error) Create(Guid transformId, Guid clientId, Guid salemanId, Guid contractId, string name)
        {
            string error = ValidateInputs(clientId, salemanId, contractId, name);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var historyTransform = new HistoryTransform(transformId, clientId, salemanId, contractId, name);
            return (historyTransform, error);
        }

        public static string ValidateInputs(Guid clientId, Guid salemanId, Guid contractId, string name)
        {
            if (clientId == Guid.Empty)
            {
                return "Client ID cannot be empty.";
            }

            if (salemanId == Guid.Empty)
            {
                return "Worker ID cannot be empty.";
            }

            if (contractId == Guid.Empty)
            {
                return "Contract ID cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return "Name cannot be empty.";
            }

            return string.Empty;
        }
    }
}