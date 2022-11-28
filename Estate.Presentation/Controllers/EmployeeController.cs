namespace IvanRealEstate.Estate.Presentation.Controllers
{
    using Application.Commands.EmployeeForCompanyCommands;
    using Application.Queries.EmployeeForCompanyQueries;
    using Estate.Presentation.ActionFilter;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Shared.DataTransferObject;

    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ISender _sender;

        public EmployeeController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesForCompany(Guid companyId)
        {
            var employee = await _sender.Send(new GetEmployeesForCompanyQuery(companyId, TrackChanges: false));

            return Ok(employee);
        }

        [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
        public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
        {

            var employee = await _sender.Send(new GetEmployeeForCompanyQuery(companyId, id, TrackChanges: false));

            return Ok(employee);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var employeeForReturn = await _sender.Send(new CreateEmployeeForCompanyCommand(companyId, employee, TrackChanges: false));

            return CreatedAtRoute("GetEmployeeForCompany",
                new { companyId, id = employeeForReturn.Id }, employeeForReturn);
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateEmployeeForCompny(
            Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employeeForUpdate)
        {
            if (employeeForUpdate is null)
                return BadRequest("EmployeeForUpdateDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _sender.Send(new UpdateEmployeeForCompanyCommand(
                companyId,
                id,
                employeeForUpdate,
                CompanyTrackChanges: false,
                EmployeeTrackChanges: true));

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid id)
        {
            await _sender.Send(new DeleteEmployeeForCompanyCommand(companyId, id, TrackChanges: false));

            return NoContent();
        }
    }
}
