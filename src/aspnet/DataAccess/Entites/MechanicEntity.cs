namespace DataAccess.Entites
{
    public class MechanicEntity
    {
        public Guid MechanicId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string Surname { get; private set; } = string.Empty;
        public string Patronymic { get; private set; } = string.Empty;
        public Guid PositionId { get; private set; } = Guid.NewGuid();

    }
}