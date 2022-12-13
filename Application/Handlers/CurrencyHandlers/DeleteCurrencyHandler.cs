namespace IvanRealEstate.Application.Handlers.CurrencyHandlers
{
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.CurrencyCommands;

    public sealed class DeleteCurrencyHandler : IRequestHandler<DeleteCurrencyCommand, Unit>
    {

        private readonly IRepositoryManager _repositoryManager;

        public DeleteCurrencyHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = await CheckerForCurrency.CheckIfCurrencyExistAndReturnIt(_repositoryManager, request.CurrencyId, request.TrackChanges);

            _repositoryManager.Currency.DeleteCurrency(currency);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
