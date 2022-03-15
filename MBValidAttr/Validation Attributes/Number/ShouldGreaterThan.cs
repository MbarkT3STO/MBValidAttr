using System;
using System.ComponentModel.DataAnnotations;

namespace MBValidAttr.Validation_Attributes.Number
{
    /// <summary>
    /// Ensuring that the value of the property is greater than a given value
    /// </summary>
    public class ShouldGreaterThan : ValidationAttribute
    {
        private readonly decimal _valueToBeChecked;
        private readonly string _errorMessage;


        /// <param name="valueToBeChecked">Value to be checked</param>
        /// <param name="errorMessage">Error message if the property's value less than or equal to <paramref name="valueToBeChecked"/></param>
        public ShouldGreaterThan(byte valueToBeChecked, string errorMessage)
        {
            _valueToBeChecked = valueToBeChecked;
            _errorMessage     = errorMessage;
        }   
        
        /// <param name="valueToBeChecked">Value to be checked</param>
        /// <param name="errorMessage">Error message if the property's value less than or equal to <paramref name="valueToBeChecked"/></param>
        public ShouldGreaterThan(int valueToBeChecked, string errorMessage)
        {
            _valueToBeChecked = valueToBeChecked;
            _errorMessage     = errorMessage;
        }  
        
        /// <param name="valueToBeChecked">Value to be checked</param>
        /// <param name="errorMessage">Error message if the property's value less than or equal to <paramref name="valueToBeChecked"/></param>
        public ShouldGreaterThan(double valueToBeChecked, string errorMessage)
        {
            _valueToBeChecked = ( decimal ) valueToBeChecked;
            _errorMessage     = errorMessage;
        }     
        
        /// <param name="valueToBeChecked">Value to be checked</param>
        /// <param name="errorMessage">Error message if the property's value less than or equal to <paramref name="valueToBeChecked"/></param>
        public ShouldGreaterThan(decimal valueToBeChecked, string errorMessage)
        {
            _valueToBeChecked = valueToBeChecked;
            _errorMessage     = errorMessage;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return Convert.ToDecimal(value) > _valueToBeChecked ? ValidationResult.Success : new ValidationResult( _errorMessage );
        }
    }
}
