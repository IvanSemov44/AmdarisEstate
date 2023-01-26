namespace IvanRealEstate.Application.Commands.OwnerImageCommands
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.OwnerImage;

    public sealed record CreateOwnerImageCommand
        (Guid OwnerId, OwnerImageForCreationDto OwnerImageForCreationDto, bool TrackChanges)
        : IRequest<OwnerImageDto>;
}
