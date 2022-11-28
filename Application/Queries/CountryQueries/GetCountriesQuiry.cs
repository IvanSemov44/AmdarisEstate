using MediatR;
using Shared.DataTransferObject.Country;

namespace Application.Queries.CountryQueries
{
    public sealed record GetCountriesQuiry(bool TrackChanges) : IRequest<IEnumerable<CountryDto>>;
}
