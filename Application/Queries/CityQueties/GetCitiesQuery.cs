using MediatR;
using Shared.DataTransferObject.City;

namespace Application.Queries.CityQueties
{
    public record GetCitiesQuery(bool TrackChanges) :IRequest<IEnumerable<CityDto>>;
}
