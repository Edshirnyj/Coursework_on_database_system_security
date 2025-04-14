namespace DataAccess.Entites
{
    public class ModelEntity
    {
        public Guid ModelId { get; private set; } = Guid.NewGuid();
        public Guid BrandId { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
    }
}