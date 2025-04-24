using System.ComponentModel.DataAnnotations;

namespace AspNetApp.Models.User
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Role { get; set; }
    }
}