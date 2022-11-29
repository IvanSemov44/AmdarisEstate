namespace IvanRealEstate.Application.Handlers.EstateHandlers
{
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
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
            var estate = await _repositoryManager.Estate.GetEstateAsync(request.EstateId, request.TrackChanges);
            if (estate is null)
                throw new EstateNotFoundException(request.EstateId);

            _repositoryManager.Estate.DeleteEstate(estate);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
