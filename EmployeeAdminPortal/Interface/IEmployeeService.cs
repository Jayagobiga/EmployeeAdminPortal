using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees(); // to get all employee list
        Employee? GetEmployeeById(Guid id); // to get employee by Id
        Employee AddEmployee(AddEmployeeDto dto); // to add employee
        Employee? UpdateEmployee(Guid id, UpdateEmployeeDto dto); // to update employee
        bool DeleteEmployee(Guid id); // to delete employee
    }
}
