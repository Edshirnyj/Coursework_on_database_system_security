namespace Core.Models
{
    public class TestDriveModel
    {
        public Guid TestId { get; set; }
        public Guid ClientId { get; set; }
        public Guid AutoId { get; set; }
        public DateTime DateOfTest { get; set; }

        private TestDriveModel(Guid testId, Guid clientId, Guid autoId, DateTime dateOfTest)
        {
            TestId = testId;
            ClientId = clientId;
            AutoId = autoId;
            DateOfTest = dateOfTest;
        }

        public static (TestDriveModel TestDriveModel, string Error) Create(Guid testId, Guid clientId, Guid autoId, DateTime dateOfTest)
        {
            string? error = ValidateInputs(clientId, autoId, dateOfTest);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var testDriveModel = new TestDriveModel(testId, clientId, autoId, dateOfTest);
            return (testDriveModel, string.Empty);
        }

        private static string? ValidateInputs(Guid clientId, Guid autoId, DateTime dateOfTest)
        {
            if (clientId == Guid.Empty)
                return "Client ID cannot be empty.";

            if (autoId == Guid.Empty)
                return "Auto ID cannot be empty.";

            if (dateOfTest == default(DateTime))
                return "Date of test cannot be empty.";

            return string.Empty;
        }
    }
}