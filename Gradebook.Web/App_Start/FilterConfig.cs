using System.Web.Mvc;
using Gradebook.Web.Common.Filters;

namespace Gradebook.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AsyncAwareHandleErrorAttribute());
        }
    }
}
