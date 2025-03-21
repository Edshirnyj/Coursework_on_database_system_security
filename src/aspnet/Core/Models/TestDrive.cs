namespace Core.Models
{
    public class TestDrive
    {
        public Guid TestDriveId { get; set; } = Guid.NewGuid();
        public Guid ClientId { get; set; }
        public Guid AutoId { get; set; }
        public DateTime DateOfTest { get; set; }
        public string FinePoints { get; set; } = string.Empty;

        // Navigation properties
        public Client? Client { get; set; }
        public Auto? Auto { get; set; }

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
            string error = string.Empty;

            if (clientId == Guid.Empty)
            {
                error = "Client ID cannot be empty.";
            }

            if (autoId == Guid.Empty)
            {
                error = "Auto ID cannot be empty.";
            }

            if (dateOfTest == default)
            {
                error = "Date of test cannot be empty.";
            }

            if (string.IsNullOrWhiteSpace(finePoints))
            {
                error = "Fine points cannot be empty.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return (null, error);
            }

            var testDrive = new TestDrive(testDriveId, clientId, autoId, dateOfTest, finePoints);
            return (testDrive, error);
        }
    }
}
