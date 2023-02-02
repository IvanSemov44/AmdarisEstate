namespace IvanRealEstate.Presentation.Controllers
{
    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using System.Text.Json;

    using IvanRealEstate.Application.Queries.EstateQuery;
    using IvanRealEstate.Shared.DataTransferObject.Estate;
    using IvanRealEstate.Application.Commands.EstateCommands;
    using IvanRealEstate.Presentation.ActionFilter;
    using IvanRealEstate.Shared.RequestFeatures;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/estates")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        private readonly ISender _sender;
        public EstateController(ISender sender)
        {
            _sender = sender;
        }


        [HttpGet("{estateId:guid}", Name = "GetEstate")]
        public async Task<IActionResult> GetEstate(Guid estateId)
        {
            var estateForReturn = await _sender.Send(new GetEstateQuery(estateId, TrackChanges: false));

            return Ok(estateForReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEstate()
        {
            var estatesForReturn = await _sender.Send(new GetEstatesQuery(TrackChanges: false));

            return Ok(estatesForReturn);
        }

        [Route("page")]
        [HttpGet]
        public async Task<IActionResult> GetEstateByPage([FromQuery] EstateParameters estateParameters)
        {

            var pagedResult = await _sender.Send(new GetEstatesByPageQuery(estateParameters, TrackChanges: false));

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.estatesDto);
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEstate([FromBody] EstateForCreationDto estateForCreationDto)
        {
            var estateForReturn = await _sender.Send(new CreateEstateCommand(estateForCreationDto));

            return CreatedAtRoute("GetEstate", new { estateId = estateForReturn.EstateId }, estateForReturn);
        }

        [HttpPut("{estateId:guid}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateEstate(Guid estateId, [FromBody] EstateForUpdateDto estateForUpdateDto)
        {
            await _sender.Send(new UpdateEstateCommand(estateId, estateForUpdateDto, TrackChanges: true));

            return NoContent();
        }

        [HttpDelete("{estateId:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteEstate(Guid estateId)
        {
            await _sender.Send(new DeleteEstateCommand(estateId, TrackChanges: false));

            return NoContent();
        }
    }
}
