namespace Application.Queries.CityQueties
{
    using MediatR;
    using Shared.DataTransferObject.City;

    public sealed record GetCitiesQuery(bool TrackChanges) :IRequest<IEnumerable<CityDto>>;
}
