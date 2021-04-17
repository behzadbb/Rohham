using AspNetCore.SEOHelper.Sitemap;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rohham.Entities.Blogs;
using Rohham.Entities.Services;
using Rohham.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rohham.Web.Site.Controllers
{
    public class SitemapController : Controller
    {
        private readonly ILogger<SitemapController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly IBlogService _blogService;
        private readonly IServiceService _serviceService;

        public SitemapController(ILogger<SitemapController> logger, IWebHostEnvironment env, IBlogService blogService, IServiceService serviceService)
        {
            _logger = logger;
            _env = env;
            _blogService = blogService;
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            return RedirectPermanent("sitemap.xml");
        }

        public IActionResult Make()
        {
            string host = Request.Scheme + "://" + Request.Host + "/";
            var list = new List<SitemapNode>();

            IList<Article> posts = _blogService.GetArticles().Where(x=>x.Active).ToList();
            foreach (var post in posts)
            {
                list.Add(new SitemapNode
                {
                    LastModified = post.ModifyDate != null ? post.ModifyDate : post.RegisterDate,
                    Priority = 0.9,
                    Url = host + "a/" + post.Id,
                    Frequency = SitemapFrequency.Weekly
                });
            }
            IList<Category> cats = _blogService.GetCategories();
            foreach (var cat in cats)
            {
                list.Add(new SitemapNode
                {
                    LastModified = DateTime.UtcNow,
                    Priority = 0.8,
                    Url = host + "c/" + cat.CatId,
                    Frequency = SitemapFrequency.Monthly
                });
            }
            IList<Service> services = _serviceService.GetServices();
            foreach (var service in services)
            {
                list.Add(new SitemapNode
                {
                    LastModified = service.ModifyDate != null ? service.ModifyDate : service.CreateDate,
                    Priority = 1.0,
                    Url = host + "s/" + service.ServiceId,
                    Frequency = SitemapFrequency.Monthly
                });
            }
            //list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codingwithesty.com/logging-in-asp-net-core", Frequency = SitemapFrequency.Yearly });
            //list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.7, Url = "https://codingwithesty.com/robots-txt-in-asp-net-core", Frequency = SitemapFrequency.Monthly });
            //list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://codingwithesty.com/versioning-asp.net-core-apiIs-with-swagger", Frequency = SitemapFrequency.Weekly });
            //list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.4, Url = "https://codingwithesty.com/configuring-swagger-asp-net-core-web-api", Frequency = SitemapFrequency.Never });

            new SitemapDocument().CreateSitemapXML(list, _env.ContentRootPath);
            System.Threading.Thread.Sleep(3000);
            return Redirect("sitemap.xml");
        }
    }
}
