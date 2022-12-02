namespace IvanRealEstate.Application.Queries.CityQueties
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.City;

    public sealed record GetCityQuery(Guid CityId,bool TrackChanges):IRequest<CityDto>;
}
