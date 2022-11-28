using MediatR;
using Shared.DataTransferObject.City;

namespace Application.Queries.CityQueties
{
    public sealed record GetCitiesQuery(bool TrackChanges) :IRequest<IEnumerable<CityDto>>;
}
