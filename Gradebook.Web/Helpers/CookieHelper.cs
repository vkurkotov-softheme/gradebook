using System;
using System.Web;
using System.Web.Security;

namespace Gradebook.Web.Helpers
{
    public static class CookieHelper
    {
        public static HttpCookie CreateCookie(string key, string value, DateTime expires)
        {
            return new HttpCookie(key, value)
            {
                HttpOnly = true,
                Path = FormsAuthentication.FormsCookiePath,
                Secure = FormsAuthentication.RequireSSL,
                Domain = FormsAuthentication.CookieDomain,
                Expires = expires
            };
        }
    }
}