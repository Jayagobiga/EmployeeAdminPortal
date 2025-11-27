using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Services.Interfaces;

namespace EmployeeAdminPortal.Services.Implementations
{
    public class EmployeeService : IEmployeeService //service class implements the interface
    {
        private readonly ApplicationDbContext _db;

        public EmployeeService(ApplicationDbContext db) // Injects Db context in constructor(Constructor DI)
        {
            _db = db;
        }

        public List<Employee> GetAllEmployees()
        {
            return _db.Employees.ToList(); //Fetch all employees from DB
        }

        public Employee? GetEmployeeById(Guid id)
        {
            return _db.Employees.Find(id); //Find a single employee by their ID.
        }

        public Employee AddEmployee(AddEmployeeDto dto)
        {
            // in AddEmployee
            var emp = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Salary = dto.Salary,
                JoiningDate = dto.JoiningDate
            };

            _db.Employees.Add(emp);
            _db.SaveChanges();
            return emp;
        }

        public Employee? UpdateEmployee(Guid id, UpdateEmployeeDto dto)
        {
            var emp = _db.Employees.Find(id); // find update and save
            if (emp == null) return null;

            // in UpdateEmployee
            emp.Name = dto.Name;
            emp.Email = dto.Email;
            emp.Phone = dto.Phone;
            emp.Salary = dto.Salary;
            emp.JoiningDate = dto.JoiningDate;

            _db.SaveChanges();
            return emp;
        }

        public bool DeleteEmployee(Guid id)
        {
            var emp = _db.Employees.Find(id); // find delete confirm
            if (emp == null) return false;

            _db.Employees.Remove(emp);
            _db.SaveChanges();
            return true;
        }
    }
}
