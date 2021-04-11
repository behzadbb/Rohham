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
            model.Categories = _blogService.GetCategories().ToList();
            model.Articles = _blogService.GetArticles().ToList();
            return View(model);
        }

        [Route("article/{id}/{title?}")]
        public IActionResult Article(int id, string title)
        {
            var article = _blogService.GetArticle(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        public IActionResult CategoryList() 
        {
            List<Category> cache;
            cache = _blogService.GetCategories().ToList();
            return View(cache);
        }
    }
}