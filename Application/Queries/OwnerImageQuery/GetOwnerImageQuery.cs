namespace IvanRealEstate.Application.Queries.OwnerImageQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.OwnerImage;

    public sealed record GetOwnerImageQuery(Guid OwnerId, Guid OwnerImageId, bool TrackChanges) 
        : IRequest<OwnerImageDto>;
}
