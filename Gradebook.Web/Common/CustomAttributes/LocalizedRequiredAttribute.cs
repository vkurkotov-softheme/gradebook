using System.ComponentModel.DataAnnotations;
using Gradebook.Translations;

namespace Gradebook.Web.Common.CustomAttributes
{
    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public LocalizedRequiredAttribute()
        {
            ErrorMessageResourceType = typeof (i18n);
            ErrorMessageResourceName = "Required";
        }
    }
}