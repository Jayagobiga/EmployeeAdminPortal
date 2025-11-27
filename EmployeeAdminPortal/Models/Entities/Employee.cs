using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$",
        ErrorMessage = "Email must be a valid Gmail address")]
        public required string Email { get; set; }


        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone must be exactly 10 digits")]
        public string? Phone { get; set; }

        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }
    }
}
