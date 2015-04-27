using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Gradebook.Web.Enums;

namespace Gradebook.Web.Common.GradebookPrincipalService
{
    public class GradebookPrincipal : IGradebookPrincipal
    {
        public GradebookPrincipal(string name)
        {
            Identity = new GenericIdentity(name);
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public IIdentity Identity { get; private set; }

        public string Email { get; set; }

        public string CultureName { get; set; }

        public int UserId { get; set; }

        public int UserRoleCode { get; set; }

        public CultureInfo Culture
        {
            get { return new CultureInfo(CultureName); }
            set { CultureName = value.Name; }
        }

        public UserRole UserRole
        {
            get { return (UserRole)UserRoleCode; }
            set { UserRoleCode = (int)value; }
        }
    }
}