
using AutoMapper;
using IvanRealEstate.Application.Commands.CurrencyCommands;
using IvanRealEstate.Contracts;
using IvanRealEstate.Entities;
using MediatR;

namespace IvanRealEstate.Application.Handlers.CurrencyHandlers
{
    internal sealed class DeleteCurrencyHandler : IRequestHandler<DeleteCurrencyCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public DeleteCurrencyHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = await _repositoryManager.Currency.GetCurrencyAsync(request.CurrencyId, request.TrackChanges);
            if (currency is null)
                throw new CurrencyNotFoundException(request.CurrencyId);

            _repositoryManager.Currency.DeleteCurrency(currency);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
