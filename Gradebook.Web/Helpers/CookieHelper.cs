using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradebook.Web.Helpers
{
    public static class CookieHelper
    {
        public static HttpCookie CreateCookie(string key, string value, DateTime expires)
        {
            return new HttpCookie(key, value)
            {
                HttpOnly = true,
                Path = System.Web.Security.FormsAuthentication.FormsCookiePath,
                Secure = System.Web.Security.FormsAuthentication.RequireSSL,
                Domain = System.Web.Security.FormsAuthentication.CookieDomain,
                Expires = expires
            };
        }
    }
}