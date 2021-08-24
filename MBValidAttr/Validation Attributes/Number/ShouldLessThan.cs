using System.ComponentModel.DataAnnotations;

namespace MBValidAttr.Validation_Attributes.Number
{
    /// <summary>
    /// Ensure that the property's value less than a given value
    /// </summary>
    public class ShouldLessThan : ValidationAttribute
    {
        private readonly decimal _valueToBeChecked;
        private readonly string  _errorMessage;


        public ShouldLessThan( decimal valueToBeChecked, string errorMessage)
        {
            _errorMessage     = errorMessage;
            _valueToBeChecked = valueToBeChecked;
        }


        protected override ValidationResult IsValid( object value , ValidationContext validationContext )
        {
            var currentValueAsDecimal = decimal.Parse( ( string ) value );

            return currentValueAsDecimal < _valueToBeChecked
                       ? ValidationResult.Success
                       : new ValidationResult( _errorMessage );
        }
    }
}