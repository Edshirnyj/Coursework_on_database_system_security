using System.ComponentModel.DataAnnotations;

namespace fullstack_app.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        
        [Required]
        [StringLength(256)]
        public string PasswordHash { get; set; }
        
        [Required]
        public Role Role { get; set; }
    }
}