using System.ComponentModel.DataAnnotations;

namespace Gradebook.Web.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}