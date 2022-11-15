
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
        public async Task<IActionResult> GetEmployeeForCompany(Guid companyId)
        {
            var employee =await  _serviceManager.EmployeeService.GetEmployeesAsync(companyId, trackChanges: false);

            return Ok(employee);
        }

        [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
        public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee =await  _serviceManager.EmployeeService.GetEmployeeAsync(companyId, id, trackChanges: false);

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var employeeForReturn =await _serviceManager.EmployeeService
                .CreateEmployeeForCompanyAsync(companyId, employee, trackChanges: false);

            return CreatedAtRoute("GetEmployeeForCompany",
                new { companyId, id = employeeForReturn.Id }, employeeForReturn);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployeeForCompny(
            Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employeeForUpdate)
        {
            if (employeeForUpdate is null)
                return BadRequest("EmployeeForUpdateDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serviceManager.EmployeeService.UpdateEmployeeForCompanyAsync(
                companyId,
                id,
                employeeForUpdate,
                compTrackChanges: false,
                empTrackChanges: true);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid id)
        {
            await _serviceManager.EmployeeService.DeleteEmployeeForCompanyAsync(companyId, id, trackChanges: false);

            return NoContent();
        }
    }
}
