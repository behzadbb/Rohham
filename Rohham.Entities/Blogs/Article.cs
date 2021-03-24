using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rohham.Entities.Blogs
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public int CatId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Url { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public string Tags { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        public string ImageThumpUrl { get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey("CatId")]
        public virtual Category Category { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
