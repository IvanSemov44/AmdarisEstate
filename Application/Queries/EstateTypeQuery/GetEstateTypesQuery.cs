namespace IvanRealEstate.Application.Queries.EstateTypeQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;

    public sealed record GetEstateTypesQuery(bool TrackChanges):IRequest<IEnumerable<EstateTypeDto>>;
}
