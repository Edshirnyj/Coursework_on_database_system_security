namespace Core.Models
{
    public class HistoryTransform
    {
        public Guid TransformId { get; set; } = Guid.NewGuid();
        public Guid ClientId { get; set; }
        public Guid WorkerId { get; set; }
        public Guid ContractId { get; set; }
        public string Name { get; set; } = string.Empty;

        public Client Client { get; set; } = null!;
        public Worker Worker { get; set; } = null!;
        public Contract Contract { get; set; } = null!;

        private HistoryTransform(Guid transformId, Guid clientId, Guid workerId, Guid contractId, string name)
        {
            TransformId = transformId;
            ClientId = clientId;
            WorkerId = workerId;
            ContractId = contractId;
            Name = name;
        }

        public static (HistoryTransform? HistoryTransform, string Error) Create(Guid transformId, Guid clientId, Guid workerId, Guid contractId, string name)
        {
            string error = string.Empty;

            if (clientId == Guid.Empty)
            {
                error = "Client ID cannot be empty.";
            }

            if (workerId == Guid.Empty)
            {
                error = "Worker ID cannot be empty.";
            }

            if (contractId == Guid.Empty)
            {
                error = "Contract ID cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Name cannot be empty.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var historyTransform = new HistoryTransform(transformId, clientId, workerId, contractId, name);
            return (historyTransform, error);
        }
    }
}