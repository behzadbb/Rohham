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
        public List<Article> Articles { get; set; }
        public List<Category> Categories { get; set; }
    }
}
