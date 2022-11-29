namespace IvanRealEstate.Presentation.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using IvanRealEstate.Shared.DataTransferObject.Estate;
    using IvanRealEstate.Application.Commands.EstateCommands;
    using IvanRealEstate.Application.Queries.EstateQuery;

    [Route("api/estates")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        private readonly ISender _sender;
        public EstateController(ISender sender)
        {
            _sender = sender;
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

            return Ok(estateForReturn);
        }
    }
}
