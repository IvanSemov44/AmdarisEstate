namespace Application.Queries.CountryQueries
{
    using MediatR;
    using Shared.DataTransferObject.Country;

    public sealed record GetCountriesQuiry(bool TrackChanges) : IRequest<IEnumerable<CountryDto>>;
}
