namespace Core.Models
{
    public class Contract
    {
        public Guid ContractId { get; private set; } = Guid.NewGuid();
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        public Guid TradeId { get; private set; } = Guid.NewGuid();
        public Guid TypeContractId { get; private set; } = Guid.NewGuid();
        public DateTime DateOfContract { get; private set; } = DateTime.Now;

        public Auto Auto { get; private set; } = null!;
        public Trade Trade { get; private set; } = null!;
        public TypeContract TypeContract { get; private set; } = null!;

        private Contract(Guid contractId, Guid autoId, Guid tradeId, Guid typeContractId, DateTime dateOfContract)
        {
            ContractId = contractId;
            AutoId = autoId;
            TradeId = tradeId;
            TypeContractId = typeContractId;
            DateOfContract = dateOfContract;
        }

        public static (Contract? Contract, string Error) Create(Guid contractId, Guid autoId, Guid tradeId, Guid typeContractId, DateTime dateOfContract)
        {
            string error = ValidateInputs(autoId, tradeId, typeContractId, dateOfContract);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var contract = new Contract(contractId, autoId, tradeId, typeContractId, dateOfContract);
            return (contract, error);
        }

        private static string ValidateInputs(Guid autoId, Guid tradeId, Guid typeContractId, DateTime dateOfContract)
        {
            if (autoId == Guid.Empty)
                return "Auto ID cannot be empty.";

            if (tradeId == Guid.Empty)
                return "Trade ID cannot be empty.";

            if (typeContractId == Guid.Empty)
                return "Type Contract ID cannot be empty.";

            if (dateOfContract > DateTime.Now)
                return "Date of contract cannot be in the future.";

            return string.Empty;
        }
    }
}
