namespace IvanRealEstate.Estate.Presentation.Controllers
{
    using Application.Commands.CompanyCommands;
    using Application.Queries.CompanyQueries;
    using Estate.Presentation.ActionFilter;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Shared.DataTransferObject;

    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ISender _sender;

        public CompanyController(ISender sender)
        {
            this._sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _sender.Send(new GetCompaniesQuery(TrackChanges: false));

            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _sender.Send(new GetCompanyQuery(id, TrackChanges: false));

            return Ok(company);
        }

        //[HttpGet("collection/{ids}", Name = "CompanyCollection")]
        //public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        //{
        //    var companies = await _serviceManager.CompanyService.GetByIdsAsync(ids, trackChanges: false);

        //    return Ok(companies);
        //}

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {
            var createdCompany = await _sender.Send<CompanyDto>(new CreateCompanyCommand(company));

            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }

        //[HttpPost("collection")]
        //public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        //{
        //    var result = await _serviceManager.CompanyService.CreateCompanyCollectionAsync(companyCollection);


        //    return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
        //}

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto companyForUpdate)
        {
            await _sender.Send(new UpdateCompanyCommand(id, companyForUpdate, TrackChanges: true));

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _sender.Send(new DeleteCompanyCommand(id,TrackChanges:false));

            return NoContent();
        }
    }
}
