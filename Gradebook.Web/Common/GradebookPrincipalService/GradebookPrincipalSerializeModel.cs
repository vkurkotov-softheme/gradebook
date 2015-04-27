using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradebook.Web.Common.GradebookPrincipalService
{
    public class GradebookPrincipalSerializeModel
    {
        public string Email { get; set; }

        public string CultureName { get; set; }

        public int UserId { get; set; }

        public int UserRoleCode { get; set; }
    }
}