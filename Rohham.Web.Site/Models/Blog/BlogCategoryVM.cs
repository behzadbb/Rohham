using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rohham.Web.Site.Models.Blog
{
    public class BlogCategoryVM
    {
        public int CatId { get; set; }
        public bool Active { get; set; }
        public int? ParentId { get; set; }
        public List<BlogCategoryVM> BlogCategories { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
