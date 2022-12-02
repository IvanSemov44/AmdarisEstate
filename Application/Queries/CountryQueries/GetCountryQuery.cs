namespace IvanRealEstate.Application.Queries.CountryQueries
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Country;

    public sealed record GetCountryQuery(Guid CountryId,bool TrackChanges):IRequest<CountryDto>;
}
