using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        #region Private Methods

        private static MvcHtmlString AddDatePickerJavascriptCall(MvcHtmlString editorString, string id)
        {
            var scriptPart = string.Format("<script>$(function() {{$(\"#{0}\").datepicker();}})</script>", id);
            return MvcHtmlString.Create(editorString + scriptPart);
        }

        #endregion
    }
}