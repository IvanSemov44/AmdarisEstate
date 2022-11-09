
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
    }
}
