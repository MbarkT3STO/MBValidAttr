using System;
using System.ComponentModel.DataAnnotations;

namespace MBValidAttr.Validation_Attributes
{
    /// <summary>
    /// Ensuring that the value of the property is greater than a given value
    /// </summary>
    public class ShouldGreaterThan : ValidationAttribute
    {
        private readonly dynamic _valueToBeChecked;
        private readonly string _errorMessage;


        /// <param name="valueToBeChecked">Value to be checked</param>
        /// <param name="errorMessage">Error message if the property's value less than or equal to <paramref name="valueToBeChecked"/></param>
        public ShouldGreaterThan(object valueToBeChecked, string errorMessage)
        {
            _valueToBeChecked = valueToBeChecked;
            _errorMessage = errorMessage;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (Convert.ChangeType(value, value.GetType()) > Convert.ChangeType(_valueToBeChecked, value.GetType()))
                ? ValidationResult.Success
                : new ValidationResult(_errorMessage);
        }
    }
}
