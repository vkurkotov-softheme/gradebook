using System.Web;
using Gradebook.DAL.EF;

namespace Gradebook.Web.Common.FormsAuthentification
{
    public interface IFormsAuthenticationService
    {
        void SignIn(User user, bool createPersistentCookie);

        void ReissueTicket(User user, HttpResponseBase response);

        void SignOut();
    }
}
