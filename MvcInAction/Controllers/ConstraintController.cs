using System.Web.Mvc;

namespace MvcInAction.Controllers
{
    public class ConstraintController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "This is the index page of the Constraint controller";
            return View();
        }

        public ActionResult Constraint(int id)
        {
            ViewBag.Message = $"This is the page with 'constraint', you sent {id} as parameter.";
            return View("Index");
        }

        public ActionResult NoConstraint(string id)
        {
            ViewBag.Message = $"This is the page with 'no constraint', you sent {id} as parameter.";
            return View("Index");
        }
    }
}