namespace DataAccess.Entites
{
    public class BrandEntity
    {
        public Guid BrandId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public Guid ContinentId { get; private set; }

    }
}