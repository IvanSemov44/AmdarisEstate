namespace IvanRealEstate.Application.Queries.ImageQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Image;

    public sealed record GetImagesQuery(Guid EstateId, bool TrackChanges):IRequest<IEnumerable<ImageDto>>;
}
