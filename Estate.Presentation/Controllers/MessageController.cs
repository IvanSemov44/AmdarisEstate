namespace IvanRealEstate.Presentation.Controllers
{
    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Presentation.ActionFilter;
    using IvanRealEstate.Application.Queries.MessageQuery;
    using IvanRealEstate.Shared.DataTransferObject.Message;
    using IvanRealEstate.Application.Commands.MessageCommands;

    [Route("api/owner/{ownerId}/messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ISender _sender;

        public MessageController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessageForUser(Guid ownerId)
        {
            var messagesForReturn = await _sender.Send(new GetAllMessagesQuery(ownerId, TrackChanges: false));

            return Ok(messagesForReturn);
        }

        [HttpGet("{messageId:guid}", Name = "GetMessageForOwner")]
        public async Task<IActionResult> GetMessageForOwner(Guid ownerId, Guid messageId)
        {
            var messageForReturn = await _sender.Send(new GetMessageQuery(ownerId, messageId, TrackChanges: false));

            return Ok(messageForReturn);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMessageForOwner(
            Guid ownerId, [FromBody] MessageForCreationDto messageForCreation)
        {
            var messageForReturn = await _sender.Send(new CreateMessageCommand(ownerId, messageForCreation,TrackChanges:false));

            return CreatedAtRoute("GetMessageForOwner", new {ownerId, messageId = messageForReturn.Id }, messageForReturn);
        }

        [HttpPut("{messageId:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateMessageForOwner(
            Guid ownerId, Guid messageId, [FromBody]MessageForUpdateDto messageForUpdate)
        {
            await _sender.Send(new UpdateMessageCommand(ownerId, messageId, messageForUpdate, TrackChages: true));
            
            return NoContent();
        }

        [HttpDelete("{messageId:guid}")]
        public async Task<IActionResult> DeleteMessageForOwner(Guid ownerId, Guid messageId)
        {
            await _sender.Send(new DeleteMessageCommand(ownerId, messageId, TrackChanges: false));

            return NoContent();
        }
    }
}
