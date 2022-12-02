namespace IvanRealEstate.Application.Queries.EstateTypeQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;

    public sealed record GetEstateTypeQuery(Guid EstateTypeId,bool TrackChanges):IRequest<EstateTypeDto>;
}
