using System.Web.Mvc;

namespace Gradebook.Web.Common.Binders
{
    public class TrimModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
        ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueResult == null || string.IsNullOrEmpty(valueResult.AttemptedValue))
            {
                return null;
            }

            return valueResult.AttemptedValue.Trim();
        }
    }
}