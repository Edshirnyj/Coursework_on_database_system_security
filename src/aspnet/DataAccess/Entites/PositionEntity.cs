namespace DataAccess.Entites
{
    public class PositionEntity
    {
        public Guid PositionId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
    }
}