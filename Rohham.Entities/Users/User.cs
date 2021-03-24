using System.ComponentModel.DataAnnotations;

namespace Rohham.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Username { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
