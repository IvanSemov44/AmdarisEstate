using MediatR;
using Shared.DataTransferObject.City;

namespace Application.Queries.CityQueties
{
    public sealed record GetCityQuery(Guid CityId,bool TrackChanges):IRequest<CityDto>;
}
