using System.Web.Mvc;
using Gradebook.Business.Enums;
using Gradebook.Web.Common.GradebookPrincipalService;

namespace Gradebook.Web.Controllers
{
    [ChildActionOnly]
    public class NavigationController : Controller
    {
        public ActionResult LeftMenu()
        {
            var userType = User.Identity.IsAuthenticated ? ((GradebookPrincipal)User).UserType : UserType.None;
            return PartialView(userType);
        }

        public ActionResult TopRightMenu()
        {
            return PartialView(User.Identity.IsAuthenticated);
        }
    }
}