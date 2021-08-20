using System;
using System.ComponentModel.DataAnnotations;

namespace MBValidAttr.Validation_Attributes.Time
{
    /// <summary>
    /// Ensuring that the value of the property is not equals to a given TIME
    /// </summary>
    public class TimeShouldNotEqual : ValidationAttribute
    {
        private readonly string _valueToBeChecked;
        private readonly string _errorMessage;


        /// <param name="valueToBeChecked">Value to be checked</param>
        /// <param name="errorMessage">Error message if the property's value is equal to <paramref name="valueToBeChecked"/></param>
        public TimeShouldNotEqual(string valueToBeChecked, string errorMessage)
        {
            _valueToBeChecked = valueToBeChecked;
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ( TimeSpan.Parse(_valueToBeChecked) == TimeSpan.Parse(value.ToString()))
                 ? new ValidationResult(_errorMessage)
                 : ValidationResult.Success;
        }
    }
}
