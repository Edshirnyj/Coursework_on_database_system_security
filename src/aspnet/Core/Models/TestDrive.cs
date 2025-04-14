namespace Core.Models
{
    public class TestDrive
    {
        public Guid TestId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        public DateTime DateOfTest { get; private set; } = DateTime.Now;
        public string FinePoints { get; private set; } = string.Empty;

        public Client? Client { get; private set; } = null!;
        public Auto? Auto { get; private set; } = null!;

        private TestDrive(Guid testId, Guid clientId, Guid autoId, DateTime dateOfTest, string finePoints)
        {
            TestId = testId;
            ClientId = clientId;
            AutoId = autoId;
            DateOfTest = dateOfTest;
            FinePoints = finePoints;
        }

        public static (TestDrive? TestDrive, string Error) Create(Guid testId, Guid clientId, Guid autoId, DateTime dateOfTest, string finePoints)
        {
            string error = ValidateInputs(clientId, autoId, dateOfTest, finePoints);

            if (!string.IsNullOrEmpty(error))
                return (null, error);

            var testDrive = new TestDrive(testId, clientId, autoId, dateOfTest, finePoints);
            return (testDrive, error);
        }

        private static string ValidateInputs(Guid clientId, Guid autoId, DateTime dateOfTest, string finePoints)
        {
            if (clientId == Guid.Empty)
                return "Client ID cannot be empty.";

            if (autoId == Guid.Empty)
                return "Auto ID cannot be empty.";

            if (dateOfTest > DateTime.Now)
                return "Date of test cannot be in the future.";

            if (string.IsNullOrWhiteSpace(finePoints))
                return "Fine points cannot be empty.";

            if (finePoints.Length > 500)
                return "Fine points cannot exceed 500 characters.";

            return string.Empty;
        }
    }
}
