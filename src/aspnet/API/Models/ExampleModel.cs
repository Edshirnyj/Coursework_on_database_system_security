using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ExampleModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}