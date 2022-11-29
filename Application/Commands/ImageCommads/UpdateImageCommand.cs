namespace IvanRealEstate.Application.Commands.ImageCommads
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Image;

    public sealed record UpdateImageCommand(
        Guid EstateId,
        Guid ImageId,
        ImageForUpdateDto ImageForUpdateDto,
        bool EstateTrackChanges,
        bool ImageTrackChanges)
        :IRequest;
}
