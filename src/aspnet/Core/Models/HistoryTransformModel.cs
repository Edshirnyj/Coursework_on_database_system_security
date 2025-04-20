namespace Core.Models
{
    public class HistoryTransformModel
    {
        public Guid HistoryId { get; set; }
        public Guid SalesmanId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ContractId { get; set; }
        public string? Name { get; set; }

        private HistoryTransformModel(Guid historyId, Guid salesmanId, Guid clientId, Guid contractId, string? name)
        {
            HistoryId = historyId;
            SalesmanId = salesmanId;
            ClientId = clientId;
            ContractId = contractId;
            Name = name;
        }

        public static (HistoryTransformModel HistoryTransformModel, string Error) Create(Guid historyId, Guid salesmanId, Guid clientId, Guid contractId, string? name)
        {
            string? error = ValidateInputs(salesmanId, clientId, contractId, name);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var historyTransformModel = new HistoryTransformModel(historyId, salesmanId, clientId, contractId, name);
            return (historyTransformModel, string.Empty);
        }

        private static string? ValidateInputs(Guid salesmanId, Guid clientId, Guid contractId, string? name)
        {
            if (salesmanId == Guid.Empty)
                return "Salesman ID cannot be empty.";

            if (clientId == Guid.Empty)
                return "Client ID cannot be empty.";

            if (contractId == Guid.Empty)
                return "Contract ID cannot be empty.";

            if (string.IsNullOrWhiteSpace(name))
                return "Name cannot be empty.";

            return string.Empty;
        }        
    }
}