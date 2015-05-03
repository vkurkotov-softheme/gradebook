using System.Web.Mvc;
using Gradebook.Business.Enums;
using Gradebook.Web.Common.CustomAttributes;

namespace Gradebook.Web.Controllers
{
    [LevelAuthorize(UserType.Administrator, UserType.Teacher, UserType.Parent)]
    public class AdminController : Controller
    {
        public ActionResult AddTeacher()
        {
            return View();
        }
    }
}
