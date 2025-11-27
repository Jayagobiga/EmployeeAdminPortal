using System;
using System.ComponentModel.DataAnnotations;
using EmployeeAdminPortal.Validation;

namespace EmployeeAdminPortal.Models
{
    public class AddEmployeeDto
    {
        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$",
        ErrorMessage = "Email must be a valid Gmail address")]
        public required string Email { get; set; }


        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone must be exactly 10 digits")]
        public string? Phone { get; set; }


        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Joining date is required")]
        [DataType(DataType.Date)]
        [BeforeDate("2010-01-01", ErrorMessage = "Joining date must be before 01-Jan-2010")]
        public DateTime JoiningDate { get; set; }
    }
}
