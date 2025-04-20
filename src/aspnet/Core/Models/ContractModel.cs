namespace Core.Models
{
    public class ContractModel
    {
        public Guid ContractId { get; set; }
        public Guid ClientId { get; set; }
        public Guid AutoId { get; set; }
        public Guid TradeId { get; set; }
        public Guid TypeContractId { get; set; }
        public DateTime DateOfContract { get; set; }

        private ContractModel(Guid contractId, Guid clientId, Guid autoId, Guid tradeId, Guid typeContractId, DateTime dateOfContract)
        {
            ContractId = contractId;
            ClientId = clientId;
            AutoId = autoId;
            TradeId = tradeId;
            TypeContractId = typeContractId;
            DateOfContract = dateOfContract;
        }

        public static (ContractModel ContractModel, string Error) Create(Guid contractId, Guid clientId, Guid autoId, Guid tradeId, Guid typeContractId, DateTime dateOfContract)
        {
            string? error = ValidateInputs(clientId, autoId, tradeId, typeContractId, dateOfContract);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var contractModel = new ContractModel(contractId, clientId, autoId, tradeId, typeContractId, dateOfContract);
            return (contractModel, string.Empty);
        }

        private static string? ValidateInputs(Guid clientId, Guid autoId, Guid tradeId, Guid typeContractId, DateTime dateOfContract)
        {
            if (clientId == Guid.Empty)
                return "Client ID cannot be empty.";

            if (autoId == Guid.Empty)
                return "Auto ID cannot be empty.";

            if (tradeId == Guid.Empty)
                return "Trade ID cannot be empty.";

            if (typeContractId == Guid.Empty)
                return "Type Contract ID cannot be empty.";

            if (dateOfContract > DateTime.UtcNow)
                return "Date of contract cannot be in the future.";

            return string.Empty;
        }      
    }
}