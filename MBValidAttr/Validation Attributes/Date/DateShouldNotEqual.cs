using System;
using System.ComponentModel.DataAnnotations;

namespace MBValidAttr.Validation_Attributes.Date
{
    /// <summary>
    /// Ensuring that the value of the property is not equals to a given DATE
    /// </summary>
    public class DateShouldNotEqual : ValidationAttribute
    {
        private string _valueToBeChecked;
        private string _errorMessage;


        /// <param name="valueToBeChecked">Value to be checked</param>
        /// <param name="errorMessage">Error message if the property's value is equal to <paramref name="valueToBeChecked"/></param>
        public DateShouldNotEqual(string valueToBeChecked, string errorMessage)
        {
            _valueToBeChecked= valueToBeChecked;
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           //return (Convert.ChangeType(_valueToBeChecked, value.GetType()) == Convert.ChangeType(value, value.GetType())) 
           return (Convert.ToDateTime(_valueToBeChecked) == Convert.ToDateTime(value)) 
                ? new ValidationResult(_errorMessage)
                : ValidationResult.Success;
        }
    }
}
