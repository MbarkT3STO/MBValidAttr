using System;
using System.ComponentModel.DataAnnotations;

namespace MBValidAttr.Validation_Attributes.Time
{
    /// <summary>
    /// Ensure that the value of the property is between two given hours
    /// </summary>
    public class TimeShouldBetween : ValidationAttribute
    {
        private readonly int    _startHour;
        private readonly int    _endHour;
        private readonly string _errorMessage;

        /// <param name="startHour">Min Hour (Should in 24H format)</param>
        /// <param name="endHour">Max Hour (Should in 24H format)</param>
        /// <param name="errorMessage">Error message if the property's value not between the given hours</param>
        public TimeShouldBetween( int startHour , int endHour , string errorMessage = null )
        {
            _startHour    = startHour;
            _endHour      = endHour;
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid( object value , ValidationContext validationContext )
        {
            var currentValueAsTime = TimeSpan.Parse( value.ToString() );
            var currentHour        = currentValueAsTime.Hours;

            return currentHour >= _startHour && currentHour <= _endHour
                       ? ValidationResult.Success
                       : new ValidationResult( _errorMessage ?? $"Given value not between {_startHour} and {_endHour}" );
        }
    }
}