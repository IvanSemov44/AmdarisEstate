namespace IvanRealEstate.Application.Handlers.EstateHandlers
{
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.EstateCommands;

    internal sealed class DeleteEstateHandler : IRequestHandler<DeleteEstateCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteEstateHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        
        public async Task<Unit> Handle(DeleteEstateCommand request, CancellationToken cancellationToken)
        {
            var estate = await CheckerForEstate.CheckIfCurrencyExistAndReturnIt(_repositoryManager, request.EstateId, request.TrackChanges);

            _repositoryManager.Estate.DeleteEstate(estate);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
