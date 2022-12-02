namespace IvanRealEstate.Application.Handlers.EstateTypeHandler
{
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Application.Commands.EstateTypeCommands;

    internal sealed class DeleteEstateTypeHandler : IRequestHandler<DeleteEstateTypeCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteEstateTypeHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteEstateTypeCommand request, CancellationToken cancellationToken)
        {
            var estateTypeEntity = await _repositoryManager.EstateType.GetEstateTypeAsync(request.EstateTypeId, request.TrackChanges);
            if (estateTypeEntity is null)
                throw new EstateTypeNotFoundException(request.EstateTypeId);

            _repositoryManager.EstateType.DeleteEstateType(estateTypeEntity);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
