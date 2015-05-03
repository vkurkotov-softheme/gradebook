using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gradebook.Business.Enums;
using Gradebook.Business.Exceptions;
using Gradebook.Translations;
using Gradebook.Web.Common.GradebookPrincipalService;

namespace Gradebook.Web.Common.CustomAttributes
{
    public class LevelAuthorizeAttribute : AuthorizeAttribute
    {
        public LevelAuthorizeAttribute(params UserType[] userTypes)
        {
            AccessLevel = userTypes;
        }

        public UserType[] AccessLevel { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            if (AccessLevel.Any(al => al == ((GradebookPrincipal)httpContext.User).UserType))
            {
                return true;
            }

            throw new NotAuthorizedException(i18n.NotAuthorizedException);
        }
    }
}