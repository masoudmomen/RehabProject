using System.ComponentModel.DataAnnotations;

namespace Rehab.Infrastructure.Settings
{
    public class FutureAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date.Date > DateTime.Today)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("The expiration date must be later than today. ");
            }

            return ValidationResult.Success;
        }
    }
}
