using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Web.Common.GradebookPrincipalService
{
    public interface IGradebookPrincipal : IPrincipal
    {
        string Email { get; set; }

        string CultureName { get; set; }

        int UserId { get; set; }

        int UserTypeCode { get; set; }
    }
}
