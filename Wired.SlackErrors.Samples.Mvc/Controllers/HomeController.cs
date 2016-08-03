using System;
using System.Web.Mvc;

namespace Wired.SlackErrors.Samples.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Throw()
        {
            throw new ApplicationException("This is a test error!");
        }
    }
}