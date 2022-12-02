namespace IvanRealEstate.Application.Handlers.CurrencyHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Currency;
    using IvanRealEstate.Application.Queries.CurrencyQueries;

    internal sealed class GetCurrencyHandler : IRequestHandler<GetCurrencyQuery, CurrencyDto>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetCurrencyHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<CurrencyDto> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            var currency = await CheckerForCurrency.CheckIfCurrencyExistAndReturnIt(_repositoryManager, request.CurrencyId, request.TrackChanges);

            var currencyForReturn = _mapper.Map<CurrencyDto>(currency);

            return currencyForReturn;
        }
    }
}
