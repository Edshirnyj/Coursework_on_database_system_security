using System.ComponentModel.DataAnnotations;

namespace AspNetApp.Models.Salesman
{
    public class SalesmanModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public decimal SalesTarget { get; set; }

        public decimal SalesAchieved { get; set; }

        public DateTime DateHired { get; set; }
    }
}