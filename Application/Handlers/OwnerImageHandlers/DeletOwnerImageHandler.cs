namespace IvanRealEstate.Application.Handlers.OwnerImageHandlers
{
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.ImageHandlers;
    using IvanRealEstate.Application.Handlers.EstateHandlers;
    using IvanRealEstate.Application.Commands.OwnerImageCommands;

    public sealed class DeleteImageHandler : IRequestHandler<DeleteOwnerImageCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteImageHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(DeleteOwnerImageCommand request, CancellationToken cancellationToken)
        {
            var image = await CheckerForOwnerImage.CheckIfOwnerImageExistAndReturnIt
                (_repositoryManager, request.OwnerId, request.OwnerImageId, request.TrackChanges);

            _repositoryManager.OwnerImage.DeleteOwnerImage(image);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
