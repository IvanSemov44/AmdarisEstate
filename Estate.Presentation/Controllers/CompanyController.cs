using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Estate.Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CompanyController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                var companies = _serviceManager.CompanyService.GetAllCompany(trackChanges: false);

                return Ok(companies);
            }
            catch
            {
                return StatusCode(500, "Internal service error");
            }
        }
    }
}
