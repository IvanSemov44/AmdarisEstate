namespace IvanRealEstate.Presentation.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Presentation.ActionFilter;
    using IvanRealEstate.Shared.DataTransferObject.Country;
    using IvanRealEstate.Application.Queries.CountryQueries;
    using IvanRealEstate.Application.Commands.CountryCommands;

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

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _sender.Send(new GetCountriesQuiry(TrackChanges: false));

            return Ok(countries);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCountry(CountryForCreationDto countryForCreationDto)
        {
            var createdCountry = await _sender.Send(new CreateCountryCommand(countryForCreationDto));

            return CreatedAtRoute("GetCountryById", new { countryId = createdCountry.CountryId }, createdCountry);
        }

        [HttpPut("{countryId:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCountry(Guid countryId, [FromBody] CountryForUpdateDto countryForUpdateDto)
        {
            await _sender.Send(new UpdateCountryCommand(countryId, countryForUpdateDto, TrackChanges: true));

            return NoContent();
        }

        [HttpDelete("{countryId:guid}")]
        public async Task<IActionResult> DeleteCountry(Guid countryId)
        {
            await _sender.Send(new DeleteCountryCommand(countryId, TrackChanges: false));

            return NoContent();
        }
    }
}
