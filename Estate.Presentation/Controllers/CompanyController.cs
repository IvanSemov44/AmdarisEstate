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
        public IActionResult GetCompanies()
        {
            var companies = _serviceManager.CompanyService.GetAllCompany(trackChanges: false);

            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        public IActionResult GetCompny(Guid id)
        {
            var company = _serviceManager.CompanyService.GetCompany(id, trackChanges: false);

            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany(CompanyForCreationDto company)
        {
            if (company is null)
                return BadRequest("CompanyForCreationDto is null");

            var createdCompany = _serviceManager.CompanyService.CreateCompany(company);

            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }
    }
}
