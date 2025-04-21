using System.ComponentModel.DataAnnotations;

namespace fullstack_mini_project.Models
{
    public class DatabaseModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // Add additional properties that map to your database columns here
    }
}