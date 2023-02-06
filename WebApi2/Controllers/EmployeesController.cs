using Microsoft.AspNetCore.Mvc;
using WebApi2.Repository;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employee)
        {
            _employeeRepository = employee;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employee = await _employeeRepository.GetEmployeesAsync();
            return employee.Any() 
                ? Ok(employee) 
                : NoContent();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            return employee != null 
                ? Ok(employee) 
                : NotFound("Id not found!");
        }

    }
 
}
