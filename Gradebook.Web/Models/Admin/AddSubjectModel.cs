using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Gradebook.Translations;
using Gradebook.Web.Common.CustomAttributes;

namespace Gradebook.Web.Models.Admin
{
    public class AddSubjectModel
    {
        [LocalizedRequired]
        [Display(Name = "Subject", ResourceType = typeof(i18n))]
        [StringLength(50, ErrorMessageResourceType = typeof(i18n), ErrorMessageResourceName = "StringMaxLengthError")]
        public string Subject { get; set; }
    }
}