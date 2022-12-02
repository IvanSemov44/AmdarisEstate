namespace IvanRealEstate.Application.Handlers.ImageHandlers
{
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Application.Commands.ImageCommads;

    internal sealed class DeleteImageHandler : IRequestHandler<DeleteImageCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteImageHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var estate = await _repositoryManager.Estate.GetEstateAsync(request.EstateId, request.TrackChanges);
            if (estate is null)
                throw new EstateNotFoundException(request.EstateId);

            var image = await _repositoryManager.Image.GetImageAsync(request.EstateId, request.ImageId, request.TrackChanges);
            if (image is null)
                throw new ImageNotFoundException(request.ImageId);

            _repositoryManager.Image.DeleteImage(image);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
