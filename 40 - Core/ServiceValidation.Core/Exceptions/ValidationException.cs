using System;
using System.Collections.Generic;

namespace ServiceValidation.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string> ValidationErrors { get; set; }

        public ValidationException(IDictionary<string, string> validationErrors)
        {
            ValidationErrors = validationErrors;
        }
    }
}