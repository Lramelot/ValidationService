using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServiceValidation.Core.Constants;

namespace ServiceValidation.Presentation.Filters
{
    public class ImportModelState : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Controller is Controller controller)
            {
                var modelStateDictionary = controller.TempData[ValidationConstants.ModelState] as Dictionary<string, string> ?? new Dictionary<string, string>();
                var viewModelDictionary = controller.TempData[ValidationConstants.ViewModel] as Dictionary<string, string> ?? new Dictionary<string, string>();

                foreach (var viewModelKeyValuePair in viewModelDictionary)
                {
                    if (modelStateDictionary.TryGetValue(viewModelKeyValuePair.Key, out var errorString))
                    {
                        context.ModelState.AddModelError(viewModelKeyValuePair.Key, errorString);
                    }

                    context.ModelState.SetModelValue(viewModelKeyValuePair.Key, new ValueProviderResult(viewModelKeyValuePair.Value, CultureInfo.InvariantCulture));
                }
            }

            base.OnActionExecuted(context);
        }
    }
}