using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rohham.Web.Site.Models.Blog
{
    public class ArticleVM
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int CatId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public List<string> Tags { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string ImageThumpUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
