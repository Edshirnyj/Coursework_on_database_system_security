namespace Core.Models
{
    public class TestDrive
    {
        public Guid TestDriveId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; }
        public Guid AutoId { get; private set; }
        public DateTime DateOfTest { get; private set; }
        public string FinePoints { get; private set; } = string.Empty;

        // Navigation properties
        public Client? Client { get; private set; }
        public Auto? Auto { get; private set; }

        private TestDrive(Guid testDriveId, Guid clientId, Guid autoId, DateTime dateOfTest, string finePoints)
        {
            TestDriveId = testDriveId;
            ClientId = clientId;
            AutoId = autoId;
            DateOfTest = dateOfTest;
            FinePoints = finePoints;
        }

        public static (TestDrive? TestDrive, string Error) Create(Guid testDriveId, Guid clientId, Guid autoId, DateTime dateOfTest, string finePoints)
        {
            string error = ValidateInputs(clientId, autoId, dateOfTest, finePoints);

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var testDrive = new TestDrive(testDriveId, clientId, autoId, dateOfTest, finePoints);
            return (testDrive, error);
        }

        private static string ValidateInputs(Guid clientId, Guid autoId, DateTime dateOfTest, string finePoints)
        {
            if (clientId == Guid.Empty)
            {
                return "Client ID cannot be empty.";
            }

            if (autoId == Guid.Empty)
            {
                return "Auto ID cannot be empty.";
            }

            if (dateOfTest == default)
            {
                return "Date of test cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(finePoints))
            {
                return "Fine points cannot be empty.";
            }

            return string.Empty;
        }
    }
}
