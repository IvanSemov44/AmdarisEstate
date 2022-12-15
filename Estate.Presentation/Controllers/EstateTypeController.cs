namespace IvanRealEstate.Presentation.Controllers
{
    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Shared.DataTransferObject.EstateType;
    using IvanRealEstate.Application.Commands.EstateTypeCommands;
    using IvanRealEstate.Application.Queries.EstateTypeQuery;
    using IvanRealEstate.Presentation.ActionFilter;

    [Route("api/estatetypes")]
    [ApiController]
    public class EstateTypeController : ControllerBase
    {
        private readonly ISender _sender;

        public EstateTypeController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{estateTypeId:guid}", Name = "GetEstateTypeById")]
        public async Task<IActionResult> GetEstateTypeById(Guid estateTypeId)
        {
            var estateTypeForReturn = await _sender.Send(new GetEstateTypeQuery(estateTypeId, TrackChanges: false));

            return Ok(estateTypeForReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetEstateTypes()
        {
            var estateTypesForReturn = await _sender.Send(new GetEstateTypesQuery(TrackChanges: false));

            return Ok(estateTypesForReturn);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEstateType([FromBody] EstateTypeForCreationDto estateTypeForCreationDto)
        {
            var estateTypeForReturn = await _sender.Send(new CreateEstateTypeCommand(estateTypeForCreationDto));

            return CreatedAtRoute("GetEstateTypeById", new { estateTypeId = estateTypeForReturn.EstateTypeId }, estateTypeForReturn);
        }

        [HttpPut("{estateTypeId:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateEstateType(Guid estateTypeId, [FromBody] EstateTypeForUpdateDto estateTypeForUpdateDto)
        {
            await _sender.Send(new UpdateEstateTypeCommand(estateTypeId, estateTypeForUpdateDto, TrackChanges: true));

            return NoContent();
        }
        [HttpDelete("{estateTypeId:guid}")]
        public async Task<IActionResult> DeleteEstateType(Guid estateTypeId)
        {
            await _sender.Send(new DeleteEstateTypeCommand(estateTypeId, TrackChanges: false));

            return NoContent();
        }
    }
}
