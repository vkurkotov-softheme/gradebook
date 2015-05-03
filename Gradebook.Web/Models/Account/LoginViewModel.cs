using System.ComponentModel.DataAnnotations;
using Gradebook.Translations;

namespace Gradebook.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(i18n), ErrorMessageResourceName = "Required")]
        [Display(Name = "Email", ResourceType = typeof(i18n))]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(i18n), ErrorMessage=null)]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(i18n), ErrorMessageResourceName = "Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(i18n))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(i18n))]
        public bool RememberMe { get; set; }
    }
}