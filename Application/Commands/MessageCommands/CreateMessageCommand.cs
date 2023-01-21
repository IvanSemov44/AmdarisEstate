namespace IvanRealEstate.Application.Commands.MessageCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Message;

    public sealed record CreateMessageCommand(Guid OwnerId,MessageForCreationDto MessageForCreation,bool TrackChanges):
        IRequest<MessageDto>;
}
