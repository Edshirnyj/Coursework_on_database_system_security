namespace Core.Models
{
    public class Contract
    {
        public Guid ContractId { get; set; } = Guid.NewGuid();
        public Guid AutoId { get; set; }
        public Guid TradeId { get; set; }
        public Guid ContractTypeId { get; set; }
        public DateTime DateOfContract { get; set; }

        // Navigation properties for foreign keys
        public Auto Auto { get; set; } = null!;
        public Trade Trade { get; set; } = null!;
        public ContractType ContractType { get; set; } = null!;

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
            string error = string.Empty;

            if (autoId == Guid.Empty)
            {
                error = "Auto ID cannot be empty.";
            }

            if (tradeId == Guid.Empty)
            {
                error = "Trade ID cannot be empty.";
            }

            if (contractTypeId == Guid.Empty)
            {
                error = "Contract Type ID cannot be empty.";
            }

            if (dateOfContract == default)
            {
                error = "Date of contract cannot be empty.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var contract = new Contract(contractId, autoId, tradeId, contractTypeId, dateOfContract);
            return (contract, error);
        }
    }
}
