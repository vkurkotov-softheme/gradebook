using System;
using System.ComponentModel.DataAnnotations;
using Gradebook.Business.Enums;
using Gradebook.Web.Resources;

namespace Gradebook.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(i18n))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof (i18n), ErrorMessageResourceName = "StringLengthError", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(i18n))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof (i18n), Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessageResourceType = typeof (i18n), ErrorMessageResourceName = "PasswordMissmatch")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(i18n))]
        [StringLength(35,ErrorMessageResourceType = typeof(i18n), ErrorMessageResourceName = "StringMaxLengthError")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public UserType UserType { get; set; }

        public DateTime BirthDate { get; set; }

        public string ResidentalAdress { get; set; }

        public string RegisteredAdress { get; set; }

        public string Phone { get; set; }

        public string HomePhone { get; set; }
    }
}