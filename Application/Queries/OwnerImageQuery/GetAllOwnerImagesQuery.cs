namespace IvanRealEstate.Application.Queries.OwnerImageQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.OwnerImage;

    public sealed record GetAllOwnerImagesQuery(Guid OwnerId, bool TrackChanges)
        : IRequest<IEnumerable<OwnerImageDto>>;
}
