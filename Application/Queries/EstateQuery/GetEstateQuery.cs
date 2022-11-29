namespace IvanRealEstate.Application.Queries.EstateQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Estate;

    public sealed record GetEstateQuery(Guid EstateId, bool TrackChanges) : IRequest<EstateDto>;
}
