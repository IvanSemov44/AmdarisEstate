using AutoMapper;
using IvanRealEstate.Application.Commands.CurencyCommands;
using IvanRealEstate.Contracts;
using IvanRealEstate.Entities.Models;
using IvanRealEstate.Shared.DataTransferObject.Currency;
using MediatR;

namespace IvanRealEstate.Application.Handlers.CurrencyHandlers
{
    internal sealed class CreateCurrencyHandler : IRequestHandler<CreateCurrencyCommand, CurrencyDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CreateCurrencyHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<CurrencyDto> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = _mapper.Map<Currency>(request.CurrencyForCreationDto);

            _repositoryManager.Currency.CreateCurrency(currency);

            await _repositoryManager.SaveAsync();

            var currencyForReturn = _mapper.Map<CurrencyDto>(currency);

            return currencyForReturn;
        }
    }
}
