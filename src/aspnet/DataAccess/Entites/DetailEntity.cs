namespace DataAccess.Entites
{
    public class DetailEntity
    {
        public Guid DetailId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0.00m;
    }
}