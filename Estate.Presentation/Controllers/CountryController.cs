using Application.Commands.CountryCommands;
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

        [HttpPost]
        public async Task<IActionResult> CreateCountry(CountryForCreationDto countryForCreationDto)
        {
           var createdCountry =  await _sender.Send<CountryDto>(new CreateCountryCommand(countryForCreationDto));

            return Ok(createdCountry);
        }
    }
}
