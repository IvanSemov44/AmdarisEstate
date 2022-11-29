namespace IvanRealEstate.Application.Commands.ImageCommads
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Image;

    public sealed record CreateImageCommand
        (Guid EstateId,ImageForCreationDto ImageForCreationDto,bool TrackChanges):IRequest<ImageDto>;
}
