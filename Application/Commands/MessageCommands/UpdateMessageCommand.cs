namespace IvanRealEstate.Application.Commands.MessageCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Message;

    public sealed record UpdateMessageCommand(
        Guid OwnerId,
        Guid MessageId,
        MessageForUpdateDto MessageForUpdate,
        bool TrackChages
        ): IRequest;
}
