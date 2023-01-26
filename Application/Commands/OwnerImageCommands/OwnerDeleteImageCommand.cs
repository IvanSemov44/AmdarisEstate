namespace IvanRealEstate.Application.Commands.OwnerImageCommands
{
    using MediatR;

    public sealed record DeleteOwnerImageCommand(Guid OwnerId, Guid OwnerImageId, bool TrackChanges) 
        : IRequest;
}
