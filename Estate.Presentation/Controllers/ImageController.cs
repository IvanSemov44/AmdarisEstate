namespace IvanRealEstate.Presentation.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Application.Commands.ImageCommads;
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using IvanRealEstate.Application.Queries.ImageQuery;

    [Route("api/estates/{estateId}/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ISender _sender;

        public ImageController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImageForEstate(Guid estateId)
        {
            var imagesForReturn = await _sender.Send(new GetImagesQuery(estateId, TrackChanges: false));

            return Ok(imagesForReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(Guid estateId, [FromBody] ImageForCreationDto imageForCreationDto)
        {
            var imageForReturn = await _sender.Send(new CreateImageCommand(estateId, imageForCreationDto, TrackChanges: false));

            return Ok(imageForReturn);
        }
    }
}
