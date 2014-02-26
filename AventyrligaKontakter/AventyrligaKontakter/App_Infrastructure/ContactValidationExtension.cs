using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AventyrligaKontakter
{
    public static class ContactValidationExtension
    {
        public static bool Validate<T>(this T instance, out ICollection<ValidationResult> validationResults)
        {
            var validation = new ValidationContext(instance);
            validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(instance, validation, validationResults, true);
        }
    }
}