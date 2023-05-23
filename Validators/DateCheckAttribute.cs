using System.ComponentModel.DataAnnotations;

namespace shereeni_dotnet.Validators;

public class DateCheckAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var date = (DateTime?)value;
        return date < DateTime.Now ? new ValidationResult("The date must be greater than today date.") : ValidationResult.Success;
    }
}