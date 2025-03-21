namespace DataAccess.Entites
{
    public class WorkerEntity
    {
        public Guid WorkerId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public byte[] Cost { get; set; } = [];

    }
}