namespace IvanRealEstate.Application.Queries.ImageQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Image;

    public sealed record GetImageQuery(Guid EstateId,Guid ImageId,bool TrackChanges):IRequest<ImageDto>;
}
