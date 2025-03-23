namespace Core.Models
{
    public class Saleman
    {
        public Guid SalemanId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string Surname { get; private set; } = string.Empty;
        public string Patronymic { get; private set; } = string.Empty;
        public Guid PositionId { get; private set; } = Guid.NewGuid();

        public Position Position { get; private set; } = null!;

        private Saleman(Guid salemanId, string name, string surname, string patronymic, Guid positionId)
        {
            SalemanId = salemanId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            PositionId = positionId;
        }
    }
}