using System.Security.Principal;

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
