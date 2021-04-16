using System;
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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrlThump { get; set; }
        public string Facebook { get; set; }
        public string Telegram { get; set; }
        public string Whatsapp { get; set; }
        public string Twitter { get; set; }
        public string Pinterest { get; set; }
        public string Linkedin { get; set; }
        public string Youtube { get; set; }
        public bool IsTeam { get; set; }
        public int Priority { get; set; }
        public DateTime CreateDate { get; set; }
    }
}