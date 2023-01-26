namespace IvanRealEstate.Application.Commands.OwnerImageCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.OwnerImage;

    public sealed record UpdateOwnerImageCommand(
        Guid OwnerId,
        Guid OwnerImageId,
        OwnerImageForUpdateDto OwnerImageForUpdateDto,
        bool OwnerTrackChanges,
        bool OwnerImageTrackChanges)
        : IRequest;
}
