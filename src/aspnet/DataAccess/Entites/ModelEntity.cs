namespace DataAccess.Entites
{
    public class ModelEntity
    {
        public Guid ModelId { get; set; } = Guid.NewGuid();
        public Guid BrandId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    
}