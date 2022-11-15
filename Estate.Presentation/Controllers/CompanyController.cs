﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObject;

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
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _serviceManager.CompanyService.GetAllCompanyAsync(trackChanges: false);

            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompny(Guid id)
        {
            var company = await _serviceManager.CompanyService.GetCompanyAsync(id, trackChanges: false);

            return Ok(company);
        }

        [HttpGet("collection/{ids}", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var companies = await _serviceManager.CompanyService.GetByIdsAsync(ids, trackChanges: false);

            return Ok(companies);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {
            if (company is null)
                return BadRequest("CompanyForCreationDto is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdCompany = await _serviceManager.CompanyService.CreateCompanyAsync(company);

            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            var result = await _serviceManager.CompanyService.CreateCompanyCollectionAsync(companyCollection);

            return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto companyForUpdate)
        {
            if (companyForUpdate is null)
                return BadRequest("CompanyForUpdateDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serviceManager.CompanyService.UpdateCompanyAsync(id, companyForUpdate, trackChanges: true);


            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _serviceManager.CompanyService.DeleteCompanyAsync(id, trackChanges: false);

            return NoContent();
        }
    }
}
