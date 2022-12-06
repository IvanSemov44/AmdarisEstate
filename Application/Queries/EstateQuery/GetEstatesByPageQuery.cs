namespace IvanRealEstate.Application.Queries.EstateQuery
{
    using MediatR;
    using IvanRealEstate.Shared.RequestFeatures;
    using IvanRealEstate.Shared.DataTransferObject.Estate;

    public sealed record GetEstatesByPageQuery(EstateParameters EstateParameters, bool TrackChanges)
        : IRequest<(IEnumerable<EstateDto> estatesDto, MetaData? metaData)>;
}
