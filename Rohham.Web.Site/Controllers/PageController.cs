using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rohham.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rohham.Web.Site.Controllers
{
    public class PageController : Controller
    {
        private readonly IServiceService _ServiceService;
        private readonly ILogger<PageController> _logger;

        public PageController(ILogger<PageController> logger, IServiceService serviceService)
        {
            _logger = logger;
            _ServiceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("Team")]
        public IActionResult Team()
        {
            return View();
        }

        [Route("Services")]
        public IActionResult Services()
        {
            return View();
        }

        [Route("s/{id}")]
        public IActionResult Service(int id, string name)
        {
            var service = _ServiceService.GetService(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }
    }
}
