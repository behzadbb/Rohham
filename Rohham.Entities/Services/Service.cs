using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rohham.Entities.Services
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        public string Text { get; set; }

        public string Icon { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public int Priority { get; set; }

        public virtual ICollection<ServiceFeature> FeatureServices { get; set; }
        public virtual ICollection<ServiceFile> ServiceFiles { get; set; }
    }
}
