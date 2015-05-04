using System;
using System.Web;
using System.Web.Security;
using Gradebook.Business.Enums;
using Gradebook.Business.Helpers;
using Gradebook.DAL.EF;
using Gradebook.Translations;
using Gradebook.Web.Common.GradebookPrincipalService;
using Gradebook.Web.Helpers;
using Newtonsoft.Json;

namespace Gradebook.Web.Common.FormsAuthentification
{
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(User user, bool createPersistentCookie, UserType userType)
        {
            SetAuthCookie(user, createPersistentCookie, userType);
        }

        public void ReissueTicket(User user, HttpResponseBase response, UserType userType)
        {
            AssertHelper.AssertNotNull(user.Email, "userName", i18n.ValueCannotBeNullOrEmpty);

            var oldAuthCookie = FormsAuthentication.GetAuthCookie(user.Email, true);
            var oldTicket = FormsAuthentication.Decrypt(oldAuthCookie.Value);

            var isPersistent = oldTicket.Expiration != DateTime.MinValue;

            SetAuthCookie(user, isPersistent, userType);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();

            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                // Workaround for buggy FormsAuthentication sign out behavoir.
                // http://stackoverflow.com/questions/17712414/asp-net-mvc-4-cross-subdomain-authentication-cant-sign-out
                authCookie.Domain = FormsAuthentication.CookieDomain;
                authCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(authCookie);
            }

            FormsAuthentication.RedirectToLoginPage();
        }

        private static void SetAuthCookie(User user, bool isPersistent, UserType userType)
        {
            AssertHelper.AssertNotNull(user.Email, "userName", i18n.ValueCannotBeNullOrEmpty);

            var serializeModel = new GradebookPrincipalSerializeModel
            {
                CultureName = user.Language ?? "uk-UA",
                Email = user.Email,
                UserId = user.Id,
                UserTypeCode = (int)userType
            };

            var userData = JsonConvert.SerializeObject(serializeModel);

            var authTicket = new FormsAuthenticationTicket(
                2,
                user.Email,
                DateTime.Now,
                DateTime.Now.AddDays(1),
                isPersistent,
                userData,
                FormsAuthentication.FormsCookiePath);

            var encTicket = FormsAuthentication.Encrypt(authTicket);

            var formsAuthenticationCookie = CookieHelper.CreateCookie(FormsAuthentication.FormsCookieName, encTicket, authTicket.Expiration);

            HttpContext.Current.Response.Cookies.Add(formsAuthenticationCookie);
        }
    }
}