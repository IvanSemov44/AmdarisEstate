namespace IvanRealEstate.Presentation.Controllers
{
    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Shared.DataTransferObject.EstateType;
    using IvanRealEstate.Application.Commands.EstateTypeCommands;

    [Route("api/estatetypes")]
    [ApiController]
    public class EstateTypeController : ControllerBase
    {
        private readonly ISender _sender;

        public EstateTypeController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstateType([FromBody] EstateTypeForCreationDto estateTypeForCreationDto)
        {
            var estateTypeForReturn = await _sender.Send(new CreateEstateTypeCommand(estateTypeForCreationDto));

            return Ok(estateTypeForReturn);
        }
    }
}
