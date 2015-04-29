using System.Web;
using Gradebook.Business.Enums;
using Gradebook.DAL.EF;

namespace Gradebook.Web.Common.FormsAuthentification
{
    public interface IFormsAuthenticationService
    {
        void SignIn(User user, bool createPersistentCookie, UserType userRole);

        void ReissueTicket(User user, HttpResponseBase response, UserType userRole);

        void SignOut();
    }
}
