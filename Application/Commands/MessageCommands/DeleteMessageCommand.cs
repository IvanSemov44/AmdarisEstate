namespace IvanRealEstate.Application.Commands.MessageCommands
{
    using MediatR;

    public sealed record DeleteMessageCommand(Guid OwnerId, Guid MessageId, bool TrackChanges) : IRequest;
}
