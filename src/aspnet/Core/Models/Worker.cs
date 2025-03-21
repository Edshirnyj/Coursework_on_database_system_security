namespace Core.Models
{
    public class Worker
    {
        public Guid WorkerId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public byte[] Cost { get; set; } = [];

        private Worker(Guid workerId, string firstName, string secondName, string thirdName, string position, byte[] cost)
        {
            WorkerId = workerId;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            Position = position;
            Cost = cost;
        }

        public static (Worker? Worker, string Error) Create(Guid workerId, string firstName, string secondName, string thirdName, string position, byte[] cost)
        {
            string error = string.Empty;

            if (string.IsNullOrWhiteSpace(firstName))
            {
                error = "First name cannot be empty.";
            }
            
            if (string.IsNullOrWhiteSpace(secondName))
            {
                error = "Second name cannot be empty.";
            }
            
            if (string.IsNullOrWhiteSpace(thirdName))
            {
                error = "Third name cannot be empty.";
            }
            
            if (string.IsNullOrWhiteSpace(position))
            {
                error = "Position cannot be empty.";
            }
            
            if (cost == null || cost.Length == 0)
            {
                error = "Cost cannot be empty.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var worker = new Worker(workerId, firstName, secondName, thirdName, position, cost!);
            return (worker, error);
        }
    }
}