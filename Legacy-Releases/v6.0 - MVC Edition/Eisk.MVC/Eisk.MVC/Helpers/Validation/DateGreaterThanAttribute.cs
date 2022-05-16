using System;
using System.ComponentModel.DataAnnotations;
namespace Eisk.Helpers
{
    public sealed class DateGreaterThanAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' must be greater than '{1}'";
        private string _basePropertyName;

        public DateGreaterThanAttribute(string basePropertyName)
            : base(_defaultErrorMessage)
        {
            _basePropertyName = basePropertyName;
        }

        //Override default FormatErrorMessage Method  
        public override string FormatErrorMessage(string name)
        {
            return string.Format(_defaultErrorMessage, name, _basePropertyName);
        }

        //Override IsValid  
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Get PropertyInfo Object  
            var basePropertyInfo = validationContext.ObjectType.GetProperty(_basePropertyName);

            //Get Value of the property  

            var startDate = basePropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (startDate == null) return null;

            var thisDate = (DateTime)value;

            //Actual comparision  
            if (thisDate <= DateTime.Parse(startDate.ToString()))
            {
                var message = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(message, new[] { validationContext.MemberName });
            }

            //Default return - This means there were no validation error  
            return ValidationResult.Success;
        }

    }
}