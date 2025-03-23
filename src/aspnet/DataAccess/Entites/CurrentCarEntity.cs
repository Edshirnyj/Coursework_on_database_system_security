namespace DataAccess.Entites
{
    public class CurrentCarEntity
    {
        public Guid CurrentId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public Guid AutoId { get; private set; } = Guid.NewGuid();
        public DateOnly DateOfLastChange { get; private set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}