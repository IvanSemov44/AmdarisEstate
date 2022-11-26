using MediatR;
using Shared.DataTransferObject.City;

namespace Application.Queries.CityQueties
{
    public record GetCityQuery(Guid CityId,bool TrackChanges):IRequest<CityDto>;
}
