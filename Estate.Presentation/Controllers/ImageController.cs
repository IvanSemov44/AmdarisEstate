namespace IvanRealEstate.Presentation.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Application.Queries.ImageQuery;
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using IvanRealEstate.Application.Commands.ImageCommads;
    using IvanRealEstate.Presentation.ActionFilter;

    [ApiController]
    [Route("api/estates/{estateId}/images")]
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

        [HttpGet("{imageId:guid}", Name = "GetImageForEstate")]
        public async Task<IActionResult> GetImageForEstate(Guid estateId, Guid imageId)
        {
            var imageForReturn = await _sender.Send(new GetImageQuery(estateId, imageId, TrackChanges: false));

            return Ok(imageForReturn);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateImageForEstate(Guid estateId, [FromBody] ImageForCreationDto imageForCreationDto)
        {
            var imageForReturn = await _sender.Send(new CreateImageCommand(estateId, imageForCreationDto, TrackChanges: false));

            return CreatedAtRoute("GetImageForEstate", new { estateId , imageId = imageForReturn.ImageId}, imageForReturn);
        }

        [HttpPut("{imageId:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateImageForEstate(Guid estateId, Guid imageId,ImageForUpdateDto imageForUpdateDto)
        {
            await _sender.Send(new UpdateImageCommand(estateId, imageId, imageForUpdateDto, EstateTrackChanges: false, ImageTrackChanges: true));

            return NoContent();
        }

        [HttpDelete("{imageId:guid}")]
        public async Task<IActionResult> DeleteImageForEstate(Guid estateId, Guid imageId)
        {
            await _sender.Send(new DeleteImageCommand(estateId, imageId, TrackChanges: false));

            return NoContent();
        }
    }
}
