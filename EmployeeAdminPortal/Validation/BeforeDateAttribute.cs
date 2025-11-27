using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Validation
{
    // Validates that a DateTime is strictly earlier than the provided limit
    public class BeforeDateAttribute : ValidationAttribute
    {
        private readonly DateTime _maxDate;

        public BeforeDateAttribute(string maxDate) // pass "2010-01-01"
        {
            _maxDate = DateTime.Parse(maxDate);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult(ErrorMessage ?? "Date is required");

            if (value is DateTime dt)
            {
                if (dt < _maxDate) return ValidationResult.Success!;
                return new ValidationResult(ErrorMessage ?? $"Date must be before {_maxDate:dd-MMM-yyyy}");
            }

            return new ValidationResult("Invalid date value");
        }
    }
}
