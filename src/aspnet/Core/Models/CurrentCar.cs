namespace Core.Models
{
    public class CurrentCar
    {
        public Guid CurrentId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        public DateOnly DateOfLastChange { get; private set; } = DateOnly.FromDateTime(DateTime.Now);

        public Client Client { get; private set; } = null!;
        public Auto Auto { get; private set; } = null!;


        private CurrentCar(Guid currentId, Guid clientId, Guid autoId, DateOnly dateOfLastChange)
        {
            CurrentId = currentId;
            ClientId = clientId;
            AutoId = autoId;
            DateOfLastChange = dateOfLastChange;
        }

        public static (CurrentCar? CurrentCar, string Error) Create(Guid currentId, Guid clientId, Guid autoId, DateOnly dateOfLastChange)
        {
            string error = ValidateInputs(clientId, autoId, dateOfLastChange);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var currentCar = new CurrentCar(currentId, clientId, autoId, dateOfLastChange);
            return (currentCar, error);
        }

        private static string ValidateInputs(Guid clientId, Guid autoId, DateOnly dateOfLastChange)
        {
            if (clientId == Guid.Empty)
            {
                return "ClientId cannot be empty.";
            }

            if (autoId == Guid.Empty)
            {
                return "AutoId cannot be empty.";
            }

            if (dateOfLastChange == default)
            {
                return "DateOfLastChange cannot be default.";
            }

            return string.Empty;
        }

    }
}