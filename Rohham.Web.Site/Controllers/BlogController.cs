using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Rohham.Entities.Blogs;
using Rohham.Services;
using Rohham.Web.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rohham.Web.Site.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger, IBlogService blogService)
        {
            _logger = logger;
            _blogService = blogService ?? throw new ArgumentNullException(nameof(blogService));
        }

        public IActionResult Index()
        {
            BlogVM model = new BlogVM();
            //model.Categories = _blogService.GetCategories().ToList();
            model.Articles = _blogService.GetArticles().ToList();
            model.Title = "اخبار و تازه ها";
            model.Description = "اخبار و تازه ها";
            model.Keywords = "هوش مصنوعی";
            return View(model);
        }

        [Route("a/{id}")]
        public IActionResult Article(int id)
        {
            var article = _blogService.GetArticle(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        [Route("c/{id}")]
        public IActionResult Category(string id)
        {
            BlogVM model = new BlogVM();
            var articles = _blogService.GetArticlesByCatName(id).ToList();
            //model.Categories = _blogService.GetCategories().ToList();
            model.Articles = articles;
            model.Title = articles != null ? articles[0].Category.Title : id;
            model.Description = "اخبار و تازه ها";
            model.Keywords = "";
            
            if (articles == null)
            {
                return NotFound();
            }
            return View("Index", model);
        }

        public IActionResult CategoryList() 
        {
            List<Category> cache;
            cache = _blogService.GetCategories().ToList();
            return View(cache);
        }
    }
}