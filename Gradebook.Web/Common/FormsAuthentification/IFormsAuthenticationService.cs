using System.Web;
using Gradebook.Business.Enums;
using Gradebook.DAL.EF;

namespace Gradebook.Web.Common.FormsAuthentification
{
    public interface IFormsAuthenticationService
    {
        void SignIn(User user, bool createPersistentCookie, UserType userType);

        void ReissueTicket(User user, HttpResponseBase response, UserType userType);

        void SignOut();
    }
}
