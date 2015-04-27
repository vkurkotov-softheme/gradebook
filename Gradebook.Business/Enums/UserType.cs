using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Translations;

namespace Gradebook.Business.Enums
{
    public enum UserType
    {
        [Display(ResourceType = typeof(i18n), Name = "Pupil")]
        Pupil,
        [Display(ResourceType = typeof(i18n), Name = "Parent")]
        Parent,
        [Display(ResourceType = typeof(i18n), Name = "Teacher")]
        Teacher
    }
}
