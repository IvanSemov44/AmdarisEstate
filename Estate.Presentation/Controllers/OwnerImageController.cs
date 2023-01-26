namespace IvanRealEstate.Presentation.Controllers
{
    using IvanRealEstate.Application.Commands.OwnerImageCommands;
    using IvanRealEstate.Application.Queries.OwnerImageQuery;
    using IvanRealEstate.Presentation.ActionFilter;
    using IvanRealEstate.Shared.DataTransferObject.OwnerImage;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/owner/{ownerId}/image")]
    public class OwnerImageController : ControllerBase
    {
        private readonly ISender _sender;

        public OwnerImageController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwnerImage(Guid ownerId)
        {
            var imagesForReturn = await _sender.Send(new GetAllOwnerImagesQuery(ownerId, TrackChanges: false));

            return Ok(imagesForReturn);
        }

        [HttpGet("{ownerImageId:guid}", Name = "GetOwnerImage")]
        public async Task<IActionResult> GetOwnerImage(Guid ownerId, Guid ownerImageId)
        {
            var imageForReturn = await _sender.Send(new GetOwnerImageQuery(ownerId, ownerImageId, TrackChanges: false));

            return Ok(imageForReturn);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateOwnerImage(Guid ownerId, [FromBody] OwnerImageForCreationDto OwnerImageForCreationDto)
        {
            var imageForReturn = await _sender.Send(new CreateOwnerImageCommand(ownerId, OwnerImageForCreationDto, TrackChanges: false));

            return CreatedAtRoute("GetOwnerImage", new { ownerId, OwnerImageId = imageForReturn.OwnerImageId }, imageForReturn);
        }

        [HttpPut("{ownerImageId:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateOwnerImage(Guid ownerId, Guid ownerImageId, OwnerImageForUpdateDto ownerImageForUpdateDto)
        {
            await _sender.Send(new UpdateOwnerImageCommand(ownerId, ownerImageId, ownerImageForUpdateDto, OwnerTrackChanges: false, OwnerImageTrackChanges: true));

            return NoContent();
        }

        [HttpDelete("{ownerImageId:guid}")]
        public async Task<IActionResult> DeleteOwnerImage(Guid ownerId, Guid ownerImageId)
        {
            await _sender.Send(new DeleteOwnerImageCommand(ownerId, ownerImageId, TrackChanges: false));

            return NoContent();
        }
    }
}
