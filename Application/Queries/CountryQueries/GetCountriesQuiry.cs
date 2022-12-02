namespace IvanRealEstate.Application.Queries.CountryQueries
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Country;

    public sealed record GetCountriesQuiry(bool TrackChanges) : IRequest<IEnumerable<CountryDto>>;
}
