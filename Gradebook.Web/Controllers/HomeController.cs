using System.Web.Mvc;
using Gradebook.Business.Services;

namespace Gradebook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
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

        public ActionResult DivRefresh()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public string GetResult(string text)
        {
            return text;
        }
    }
}