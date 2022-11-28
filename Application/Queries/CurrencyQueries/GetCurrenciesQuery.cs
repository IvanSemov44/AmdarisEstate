namespace IvanRealEstate.Application.Queries.CurrencyQueries
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Currency;
    public sealed record GetCurrenciesQuery(bool TrackChanges) : IRequest<IEnumerable<CurrencyDto>>;
}
