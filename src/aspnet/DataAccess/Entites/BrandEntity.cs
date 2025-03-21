namespace DataAccess.Entites
{
    public class BrandEntity
    {
        public Guid BrandId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public Guid ContinentId { get; set; }

    }
}