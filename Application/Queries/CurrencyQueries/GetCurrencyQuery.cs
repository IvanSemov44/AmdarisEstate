namespace IvanRealEstate.Application.Queries.CurrencyQueries
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Currency;

    public sealed record GetCurrencyQuery(Guid CurrencyId,bool TrackChanges):IRequest<CurrencyDto>;
}
