namespace Application.Queries.CityQueties
{
    using MediatR;
    using Shared.DataTransferObject.City;

    public sealed record GetCityQuery(Guid CityId,bool TrackChanges):IRequest<CityDto>;
}
