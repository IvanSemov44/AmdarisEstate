using Application.Commands.CityCommands;
using Application.Queries.CityQueties;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObject.City;

namespace Estate.Presentation.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ISender _sender;

        public CityController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id:guid}", Name = "CityById")]
        public async Task<IActionResult> GetCity(Guid id)
        {
            var city = await _sender.Send(new GetCityQuery(id, TrackChanges: false));

            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CityForCreationDto cityForCreationDto)
        {
            var createdCity = await _sender.Send<CityDto>(new CreateCityCommand(cityForCreationDto));

            return CreatedAtRoute("CityById", new { id = createdCity.CityId }, createdCity);
        }
    }
}
