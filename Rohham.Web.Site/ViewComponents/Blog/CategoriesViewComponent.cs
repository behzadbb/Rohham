using Microsoft.AspNetCore.Mvc;
using Rohham.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rohham.Web.Site.ViewComponents.Blog
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public CategoriesViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var cats = _blogService.GetCategories().ToList();
            return View("Index", cats);
        }
    }
}