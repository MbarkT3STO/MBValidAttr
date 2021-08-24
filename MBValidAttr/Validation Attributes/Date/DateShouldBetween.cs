using System;
using System.ComponentModel.DataAnnotations;

namespace MBValidAttr.Validation_Attributes.Date
{
    /// <summary>
    /// Ensure that the property's value between two dates
    /// </summary>
    public class DateShouldBetween : ValidationAttribute
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private readonly string   _errorMessage;


        /// <summary>
        /// This constructor can be used when you have dates as string format
        /// </summary>
        /// <param name="startDate">Start date as string</param>
        /// <param name="endDate">End date as string</param>
        /// <param name="errorMessage">Error message</param>
        public DateShouldBetween(string startDate, string endDate, string errorMessage )
        {
            _startDate    = DateTime.Parse( startDate );
            _endDate      = DateTime.Parse( endDate );
            _errorMessage = errorMessage;
        }

        /// <summary>
        /// This constructor can be used when you have dates as DateTime format
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="errorMessage">Error message</param>
        public DateShouldBetween(DateTime startDate, DateTime endDate, string errorMessage )
        {
            _startDate    = startDate ;
            _endDate      = endDate;
            _errorMessage = errorMessage;
        }


        protected override ValidationResult IsValid( object value , ValidationContext validationContext )
        {
            var currentValueAsDate = DateTime.Parse( value.ToString() );

            return currentValueAsDate >= _startDate && currentValueAsDate <= _endDate
                       ? ValidationResult.Success
                       : new ValidationResult( _errorMessage );
        }
    }
}