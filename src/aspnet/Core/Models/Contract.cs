namespace Core.Models
{
    public class Contract
    {
        public Guid ContractId { get; private set; } = Guid.NewGuid();
        public Guid AutoId { get; private set; }
        public Guid TradeId { get; private set; }
        public Guid ContractTypeId { get; private set; }
        public DateTime DateOfContract { get; private set; }

        public Auto Auto { get; private set; } = null!;
        public Trade Trade { get; private set; } = null!;
        public ContractType ContractType { get; private set; } = null!;

        private Contract(Guid contractId, Guid autoId, Guid tradeId, Guid contractTypeId, DateTime dateOfContract)
        {
            ContractId = contractId;
            AutoId = autoId;
            TradeId = tradeId;
            ContractTypeId = contractTypeId;
            DateOfContract = dateOfContract;
        }

        public static (Contract? Contract, string Error) Create(Guid contractId, Guid autoId, Guid tradeId, Guid contractTypeId, DateTime dateOfContract)
        {
            string error = ValidateInputs(autoId, tradeId, contractTypeId, dateOfContract);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var contract = new Contract(contractId, autoId, tradeId, contractTypeId, dateOfContract);
            return (contract, error);
        }

        private static string ValidateInputs(Guid autoId, Guid tradeId, Guid contractTypeId, DateTime dateOfContract)
        {
            if (autoId == Guid.Empty)
            {
                return "Auto ID cannot be empty.";
            }

            if (tradeId == Guid.Empty)
            {
                return "Trade ID cannot be empty.";
            }

            if (contractTypeId == Guid.Empty)
            {
                return "Contract Type ID cannot be empty.";
            }

            if (dateOfContract == default)
            {
                return "Date of contract cannot be empty.";
            }

            return string.Empty;
        }
    }
}
