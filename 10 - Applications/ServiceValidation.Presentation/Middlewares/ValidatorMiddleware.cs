using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ServiceValidation.Core.Constants;
using ServiceValidation.Core.Exceptions;

namespace ServiceValidation.Presentation.Middlewares
{
    public class ValidationMiddleware : IMiddleware
    {
        private readonly ITempDataProvider _tempDataProvider;

        public ValidationMiddleware(ITempDataProvider tempDataProvider)
        {
            _tempDataProvider = tempDataProvider;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                _tempDataProvider.SaveTempData(context, new Dictionary<string, object>
                {
                    {ValidationConstants.ModelState, ex.ValidationErrors },
                    {ValidationConstants.ViewModel, context.Request.Form.ToDictionary(f => f.Key, f => f.Value.ToString()) }
                });

                context.Response.Redirect(context.Request.Path);
            }
        }
    }
}