using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Gradebook.Web.Helpers
{
    public static class HtmlHelperExtension
    {
        #region DatePicker

        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string id, Expression<Func<TModel, TProperty>> expression)
        {
            var editorString = htmlHelper.TextBoxFor(expression);
            return AddDatePickerJavascriptCall(editorString, id);
        }

        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string id, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            var editorString = htmlHelper.TextBoxFor(expression, htmlAttributes);
            return AddDatePickerJavascriptCall(editorString, id);
        }

        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string id, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var editorString = htmlHelper.TextBoxFor(expression, htmlAttributes);
            return AddDatePickerJavascriptCall(editorString, id);
        }

        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string id, Expression<Func<TModel, TProperty>> expression, string format)
        {
            var editorString = htmlHelper.TextBoxFor(expression, format);
            return AddDatePickerJavascriptCall(editorString, id);
        }

        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string id, Expression<Func<TModel, TProperty>> expression, string format, IDictionary<string, object> htmlAttributes)
        {
            var editorString = htmlHelper.TextBoxFor(expression, format, htmlAttributes);
            return AddDatePickerJavascriptCall(editorString, id);
        }

        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string id, Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            var editorString = htmlHelper.TextBoxFor(expression, format, htmlAttributes);
            return AddDatePickerJavascriptCall(editorString, id);
        }

        #endregion

        #region Left Menu Item

        public static MvcHtmlString ListItemAction(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            return ListItemAction(helper, linkText, actionName, controllerName, string.Empty);
        }

        /// <summary>
        /// Creats menu item that will be highlited if it is on current page
        /// </summary>
        /// <param name="helper">Call to @Html</param>
        /// <param name="linkText">Text inside a tag</param>
        /// <param name="actionName">Name of action</param>
        /// <param name="controllerName">Name of controller</param>
        /// <param name="iconClass">Css class for icon</param>
        /// <returns>Html string of menu item</returns>
        public static MvcHtmlString ListItemAction(this HtmlHelper helper, string linkText, string actionName, string controllerName, string iconClass)
        {
            var routeData = ((MvcHandler)HttpContext.Current.Handler).RequestContext.RouteData;
            var currentControllerName = (string)routeData.Values["controller"];
            var currentActionName = (string)routeData.Values["action"];
            var sb = new StringBuilder();

            sb.AppendFormat("<li{0}", (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) &&
                                                currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase)
                                                    ? " class=\"active\">" : ">"));
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            sb.AppendFormat("<a href=\"{0}\">", url.Action(actionName, controllerName));
            if (!string.IsNullOrEmpty(iconClass))
            {
                sb.AppendFormat("<span class=\"{0}\"></span>", iconClass);
            }

            sb.AppendFormat("{0}</a>", linkText);
            sb.Append("</li>");
            return new MvcHtmlString(sb.ToString());
        }

        #endregion 

        #region Private Methods

        private static MvcHtmlString AddDatePickerJavascriptCall(MvcHtmlString editorString, string id)
        {
            var scriptPart = string.Format("<script>$(function() {{$(\"#{0}\").datepicker({{changeMonth: true, changeYear: true, dateFormat: \"yy-mm-dd\"}});}})</script>", id);
            return MvcHtmlString.Create(editorString + scriptPart);
        }

        #endregion
    }
}