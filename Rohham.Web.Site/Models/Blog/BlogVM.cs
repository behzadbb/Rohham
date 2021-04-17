using Rohham.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rohham.Web.Site.Models
{
    public class BlogVM
    {
        public BlogVM()
        {
            this.Articles = new List<Article>();
            this.Categories = new List<Category>();
        }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public List<Article> Articles { get; set; }
        public List<Category> Categories { get; set; }
    }
}
