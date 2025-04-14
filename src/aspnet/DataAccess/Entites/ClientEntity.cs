namespace DataAccess.Entites
{
    public class ClientEntity
    {
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string Surname { get; private set; } = string.Empty;
        public string Patronymic { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; } = DateTime.Now; 
        public string City { get; private set; } = string.Empty;
        public Guid PassportId { get; private set; } = Guid.NewGuid();
    }
}