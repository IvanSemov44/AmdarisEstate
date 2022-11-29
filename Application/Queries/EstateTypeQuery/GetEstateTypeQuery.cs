namespace IvanRealEstate.Application.Queries.EstateTypeQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;

    public sealed record GetEstateTypeQuery(Guid EstateTypeID,bool TrackChanges):IRequest<EstateTypeDto>;
}
