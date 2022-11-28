namespace IvanRealEstate.Application.Handlers.CurrencyHandlers
{
    using MediatR;
    using AutoMapper;
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Currency;
    using IvanRealEstate.Application.Queries.CurrencyQueries;

    internal sealed class GetCurrenciesHandler : IRequestHandler<GetCurrenciesQuery, IEnumerable<CurrencyDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetCurrenciesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<CurrencyDto>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var currencies = await _repositoryManager.Currency.GetCurrenciesAsync(request.TrackChanges);

            var currenciesForReturn = _mapper.Map<IEnumerable<CurrencyDto>>(currencies);

            return currenciesForReturn;
        }
    }
}
