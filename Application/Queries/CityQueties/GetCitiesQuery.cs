namespace IvanRealEstate.Application.Queries.CityQueties
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.City;

    public sealed record GetCitiesQuery(bool TrackChanges) :IRequest<IEnumerable<CityDto>>;
}
