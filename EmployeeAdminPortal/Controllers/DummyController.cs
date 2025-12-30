using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DummyController : ControllerBase
    {
        [HttpGet("hello")]
        public IActionResult SayHello()
        {
            return Ok("Hello from Dummy API!");
        }
    }
}
