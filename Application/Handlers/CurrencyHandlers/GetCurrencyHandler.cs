

using AutoMapper;
using IvanRealEstate.Application.Queries.CurrencyQueries;
using IvanRealEstate.Contracts;
using IvanRealEstate.Entities;
using IvanRealEstate.Shared.DataTransferObject.Currency;
using MediatR;

namespace IvanRealEstate.Application.Handlers.CurrencyHandlers
{
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
            var currency = await _repositoryManager.Currency.GetCurrencyAsync(request.CurrencyId,request.TrackChanges);
            if (currency is null)
                throw new CurrencyNotFoundException(request.CurrencyId);

            var currencyForReturn = _mapper.Map<CurrencyDto>(currency);

            return currencyForReturn;
        }
    }
}
