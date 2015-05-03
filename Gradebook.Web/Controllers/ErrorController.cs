using System.Web.Mvc;

namespace Gradebook.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult PageNotFound()
        {
            var isAuthenticated = User.Identity.IsAuthenticated;
            return View(isAuthenticated);
        }
    }
}