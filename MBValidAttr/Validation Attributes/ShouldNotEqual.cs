using System;
using System.ComponentModel.DataAnnotations;

namespace MBValidAttr.Validation_Attributes
{
    /// <summary>
    /// Ensuring that the value of the property is not equal to a given value
    /// </summary>
    public class ShouldNotEqual : ValidationAttribute
    {
        private readonly dynamic _valueToBeChecked;
        private readonly string _errorMessage;

        /// <param name="valueToBeChecked">Value to be checked</param>
        /// <param name="errorMessage">Error message if the property's value equals <paramref name="valueToBeChecked"/></param>
        public ShouldNotEqual(object valueToBeChecked, string? errorMessage=null)
        {
            _valueToBeChecked=valueToBeChecked;
            _errorMessage= errorMessage ?? $"Svp Entrez une valeur différente de {_valueToBeChecked}";
        }

        protected override ValidationResult? IsValid(dynamic value, ValidationContext validationContext)
        {
            return (Convert.ChangeType(_valueToBeChecked, value.GetType()) == Convert.ChangeType(value, value.GetType())) ?
                new ValidationResult(_errorMessage) :
                ValidationResult.Success;
        }
    }
}
