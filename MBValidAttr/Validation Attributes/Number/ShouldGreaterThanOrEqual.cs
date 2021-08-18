using System;
using System.ComponentModel.DataAnnotations;

namespace MBValidAttr.Validation_Attributes.Number
{
    /// <summary>
    /// Ensuring that the value of the property is greater than or equal to a given value
    /// </summary>
    public class ShouldGreaterThanOrEqual : ValidationAttribute
    {
        private readonly dynamic _valueToBeChecked;
        private readonly string _errorMessage;


        /// <param name="valueToBeChecked">Value to be checked</param>
        /// <param name="errorMessage">Error message if the property's value less than <paramref name="valueToBeChecked"/></param>
        public ShouldGreaterThanOrEqual(object valueToBeChecked, string errorMessage)
        {
            _valueToBeChecked = valueToBeChecked;
            _errorMessage = errorMessage;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (Convert.ChangeType(value, value.GetType()) >= Convert.ChangeType(_valueToBeChecked, value.GetType()))
                ? ValidationResult.Success
                : new ValidationResult(_errorMessage);
        }
    }
}
