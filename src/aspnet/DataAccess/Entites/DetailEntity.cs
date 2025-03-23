namespace DataAccess.Entites
{
    public class DetailEntity
    {
        public Guid DetailId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; } = 0.00m;

    }
}