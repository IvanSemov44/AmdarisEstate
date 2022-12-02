namespace IvanRealEstate.Application.Handlers.ImageHandlers
{
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.ImageCommads;
    using IvanRealEstate.Application.Handlers.EstateHandlers;

    internal sealed class DeleteImageHandler : IRequestHandler<DeleteImageCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteImageHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            await CheckerForEstate.CheckIfEstateExistAndReturnIt(_repositoryManager, request.EstateId, request.TrackChanges);

            var image = await CheckerForImage.CheckIfImageExistAndReturnIt(_repositoryManager, request.EstateId, request.ImageId, request.TrackChanges);

            _repositoryManager.Image.DeleteImage(image);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
