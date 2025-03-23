namespace DataAccess.Entites
{
    public class ShopEntity
    {
        public Guid ShopId { get; private set; } = Guid.NewGuid();
        public Guid ClientId { get; private set; } = Guid.NewGuid();
        public Guid CarId { get; private set; } = Guid.NewGuid();

    }
}