using System;
using System.Globalization;
using System.Security.Principal;
using Gradebook.Business.Enums;

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

        public int UserTypeCode { get; set; }

        public CultureInfo Culture
        {
            get { return new CultureInfo(CultureName); }
            set { CultureName = value.Name; }
        }

        public UserType UserType
        {
            get { return (UserType)UserTypeCode; }
            set { UserTypeCode = (int)value; }
        }
    }
}