using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Castle.Windsor;

namespace Gradebook.Web.Common.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public sealed class AsyncAwareHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            // if the request is AJAX return JSON else view.
            if (IsAjax(filterContext))
            {
                //Because its a exception raised after ajax invocation
                //Lets return Json
                filterContext.Result = new JsonResult()
                {
                    Data = filterContext.Exception.Message,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
            }
            else
            {
                //Normal Exception
                //So let it handle by its default ways.
                base.OnException(filterContext);

            }

            // Write error logging code here if you wish.

            //if want to get different of the request
            //var currentController = (string)filterContext.RouteData.Values["controller"];
            //var currentActionName = (string)filterContext.RouteData.Values["action"];
        }
        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}