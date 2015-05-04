using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Gradebook.Translations;
using Gradebook.Web.Common.CustomAttributes;

namespace Gradebook.Web.Models.Admin
{
    public class AddTeacherModel
    {
        [LocalizedRequired]
        [Display(Name = "FirstName", ResourceType = typeof(i18n))]
        [StringLength(35, ErrorMessageResourceType = typeof(i18n), ErrorMessageResourceName = "StringMaxLengthError")]
        public string FirstName { get; set; }

        [LocalizedRequired]
        [Display(Name = "MiddleName", ResourceType = typeof(i18n))]
        [StringLength(35, ErrorMessageResourceType = typeof(i18n), ErrorMessageResourceName = "StringMaxLengthError")]
        public string MiddleName { get; set; }

        [LocalizedRequired]
        [Display(Name = "LastName", ResourceType = typeof(i18n))]
        [StringLength(35, ErrorMessageResourceType = typeof(i18n), ErrorMessageResourceName = "StringMaxLengthError")]
        public string LastName { get; set; }

        [LocalizedRequired]
        [Display(Name = "JobTitle", ResourceType = typeof(i18n))]
        [StringLength(50, ErrorMessageResourceType = typeof(i18n), ErrorMessageResourceName = "StringMaxLengthError")]
        public string JobTitle { get; set; }

        [Display(Name = "Administrator", ResourceType = typeof(i18n))]
        public bool IsAdministrator { get; set; }

    }
}