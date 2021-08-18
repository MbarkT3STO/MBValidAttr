using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MBValidAttr.Validation_Attributes.Number
{
    /// <summary>
    /// Ensure that the value of the property is between two given values
    /// </summary>
    public class ShouldBetween : ValidationAttribute
    {
        private readonly decimal _minValue;
        private readonly decimal _maxValue;
        private readonly string  _errorMessage;

        /// <summary>
        /// Ensure that the value of the property is between <see cref="minValue"/> and <see cref="maxValue"/>
        /// </summary>
        /// <param name="minValue">Min value</param>
        /// <param name="maxValue">Max value</param>
        /// <param name="errorMessage">Error message if the property's value Less than Min And/Or Greater than Max</param>
        public ShouldBetween(object minValue, object maxValue, string errorMessage)
        {
            _minValue     = Convert.ToDecimal( minValue );
            _maxValue     = Convert.ToDecimal( maxValue );
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid( object value , ValidationContext validationContext )
        {
            var currentValueAsDecimal = Convert.ToDecimal( value );

            //// Convert the Max Value to the VALUE(Current property) type
            //var minValue = Convert.ChangeType( _minValue , value.GetType() );
            
            //// Convert the Max Value to the VALUE(Current property) type
            //var maxValue = Convert.ChangeType( _maxValue , value.GetType() );

            return currentValueAsDecimal >= _minValue && currentValueAsDecimal <= _maxValue
                       ? ValidationResult.Success
                       : new ValidationResult( _errorMessage );
        }
    }
}