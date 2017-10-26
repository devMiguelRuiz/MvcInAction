using System.Web.Mvc;

namespace MvcInAction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "MVC IN ACTION";
            return View("Index");
        }
    }
}