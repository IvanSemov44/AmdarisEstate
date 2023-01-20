namespace IvanRealEstate.Presentation.Controllers
{
    using Application.Commands.CityCommands;
    using Application.Queries.CityQueties;
    using IvanRealEstate.Presentation.ActionFilter;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Shared.DataTransferObject.City;


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

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _sender.Send(new GetCitiesQuery(TrackChanges: false));

            return Ok(cities);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCity([FromBody] CityForCreationDto cityForCreationDto)
        {
            var createdCity = await _sender.Send(new CreateCityCommand(cityForCreationDto));

            return CreatedAtRoute("CityById", new { id = createdCity.CityId }, createdCity);
        }

        [HttpPut("{id:guid}", Name = "UpdateCityById")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCityById(Guid id, [FromBody] CityForUpdateDto cityForUpdateDto)
        {
            await _sender.Send(new UpdateCityCommand(id, cityForUpdateDto, TrackChanges: true));
            return NoContent();
        }

        [HttpDelete("{id:guid}", Name = "DeleteCityById")]
        public async Task<IActionResult> DeleteCityById(Guid id)
        {
            await _sender.Send(new DeleteCityCommand(id, TrackChanges: false));

            return NoContent();
        }
    }
}
