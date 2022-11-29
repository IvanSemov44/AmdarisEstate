namespace IvanRealEstate.Presentation.Controllers
{
    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Application.Queries.EstateQuery;
    using IvanRealEstate.Shared.DataTransferObject.Estate;
    using IvanRealEstate.Application.Commands.EstateCommands;

    [Route("api/estates")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        private readonly ISender _sender;
        public EstateController(ISender sender)
        {
            _sender = sender;
        }


        [HttpGet("{estateId:guid}",Name ="GetEstate")]
        public async Task<IActionResult> GetEstate(Guid estateId)
        {
            var estateForReturn = await _sender.Send(new GetEstateQuery(estateId, TrackChanges:false));
            
            return Ok(estateForReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEstate()
        {
            var estatesForReturn = await _sender.Send(new GetEstatesQuery(TrackChanges: false));

            return Ok(estatesForReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstate([FromBody] EstateForCreationDto estateForCreationDto)
        {
            var estateForReturn = await _sender.Send(new CreateEstateCommand(estateForCreationDto));

            return CreatedAtRoute("GetEstate", new { estateId= estateForReturn.EstateId },estateForReturn);
        }

        [HttpPut("{estateId:guid}")]
        public async Task<IActionResult> UpdateEstate(Guid estateId, [FromBody] EstateForUpdateDto estateForUpdateDto)
        {
            await _sender.Send(new UpdateEstateCommand(estateId, estateForUpdateDto, TrackChanges: true));

            return Ok();
        }

        [HttpDelete("{estateId:guid}")]
        public async Task<IActionResult> DeleteEstate(Guid estateId)
        {
           await _sender.Send(new DeleteEstateCommand(estateId, TrackChanges: false));

            return Ok();
        }
    }
}
