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
        None = 0,
        [Display(ResourceType = typeof(i18n), Name = "Pupil")]
        Pupil = 1,
        [Display(ResourceType = typeof(i18n), Name = "Parent")]
        Parent = 2,
        [Display(ResourceType = typeof(i18n), Name = "Teacher")]
        Teacher = 3,
        [Display(ResourceType = typeof(i18n), Name = "Administrator")]
        Administrator = 4
    }
}
