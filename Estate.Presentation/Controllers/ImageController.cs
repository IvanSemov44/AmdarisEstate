namespace IvanRealEstate.Presentation.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Application.Commands.ImageCommads;
    using IvanRealEstate.Shared.DataTransferObject.Image;

    [Route("api/estates/{estateId}/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ISender _sender;

        public ImageController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(Guid estateId, [FromBody] ImageForCreationDto imageForCreationDto)
        {
            var imageForReturn = await _sender.Send(new CreateImageCommand(estateId, imageForCreationDto, TrackChanges: false));

            return Ok(imageForReturn);
        }
    }
}
