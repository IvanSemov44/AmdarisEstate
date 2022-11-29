namespace IvanRealEstate.Application.Queries.EstateQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Estate;

    public sealed record GetEstatesQuery(bool TrackChanges):IRequest<IEnumerable<EstateDto>>;
}
