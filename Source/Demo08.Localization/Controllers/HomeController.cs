using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo08.Localization.Controllers
{
    public class HomeController : Controller
    {
        private IHtmlLocalizer<HomeController> _localizer;

        public HomeController(IHtmlLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = _localizer["This is a message."];
            return View();
        }
    }
}
