namespace IvanRealEstate.Application.Handlers.CurrencyHandlers
{
    using MediatR;

    using IvanRealEstate.Entities;
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.CurrencyCommands;

    internal sealed class DeleteCurrencyHandler : IRequestHandler<DeleteCurrencyCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteCurrencyHandler(IRepositoryManager repositoryManager)
        {
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
