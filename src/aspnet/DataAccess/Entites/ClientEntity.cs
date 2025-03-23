namespace DataAccess.Entites
{

    public class ClientEntity
    {
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string Surname { get; private set; } = string.Empty;
        public string Patronymic { get; private set; } = string.Empty;
        public DateOnly BirthDate { get; private set; }
        public string City { get; private set; } = string.Empty;
        public Guid PassportId { get; private set; }

    }
}