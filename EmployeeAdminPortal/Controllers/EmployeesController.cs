using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {   
        private readonly IEmployeeService _service; //Injects IEmployeeService

        public EmployeesController(IEmployeeService service) //(Service uses DbContext)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_service.GetAllEmployees()); // Services does everything (CRUD Logics)
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _service.GetEmployeeById(id);
            if (employee == null) return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] AddEmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // returns validation errors

            var emp = _service.AddEmployee(dto);
            return Ok(emp);
        }


        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] UpdateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _service.UpdateEmployee(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var deleted = _service.DeleteEmployee(id);
            if (!deleted) return NotFound();

            return Ok("Employee deleted");
        }
    }
}
