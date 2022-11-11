
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObject;

namespace Estate.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public EmployeeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetEmployeeForCompany(Guid companyId)
        {
            var employee = _serviceManager.EmployeeService.GetEmployees(companyId, trackChanges: false);

            return Ok(employee);
        }

        [HttpGet("{id:guid}",Name = "GetEmployeeForCompany")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee = _serviceManager.EmployeeService.GetEmployee(companyId, id, trackChanges: false);

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null");

            var employeeForReturn = _serviceManager.EmployeeService
                .CreateEmployeeForCompany(companyId, employee, trackChanges: false);

            return CreatedAtRoute("GetEmployeeForCompany",
                new { companyId, id = employeeForReturn.Id }, employeeForReturn);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployeeForCompny(
            Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employeeForUpdate)
        {
            if (employeeForUpdate is null)
                return BadRequest("EmployeeForUpdateDto object is null");

            _serviceManager.EmployeeService.UpdateEmployeeForCompany(
                companyId, 
                id, 
                employeeForUpdate,
                compTrackChanges: false,
                empTrackChanges: true);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployeeForCompany(Guid companyId,Guid id)
        {
            _serviceManager.EmployeeService.DeleteEmployeeForCompany(companyId, id, trackChanges: false);

            return NoContent();
        }
    }
}
