using Application.Commands.CountryCommands;
using Application.Queries.CountryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObject.Country;

namespace Estate.Presentation.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ISender _sender;

        public CountryController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{countryId:guid}", Name = "GetCountryById")]
        public async Task<IActionResult> GetCountryById(Guid countryId)
        {
            var country = await _sender.Send(new GetCountryQuery(countryId, TrackChanges: false));

            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry(CountryForCreationDto countryForCreationDto)
        {
            var createdCountry = await _sender.Send<CountryDto>(new CreateCountryCommand(countryForCreationDto));

            return CreatedAtRoute("GetCountryById", new {id = createdCountry.CountryId},createdCountry);
        }
    }
}
