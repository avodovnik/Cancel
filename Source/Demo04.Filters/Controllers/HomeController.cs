using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Demo04.Filters.Controllers
{
    
    [ServiceFilter(typeof(LogFilter))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [TypeFilter(typeof(BananaRequiredFilter), Arguments = new[] { "split" })]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
