namespace IvanRealEstate.Application.Handlers.EstateTypeHandler
{
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.EstateTypeCommands;

    public sealed class DeleteEstateTypeHandler : IRequestHandler<DeleteEstateTypeCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteEstateTypeHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteEstateTypeCommand request, CancellationToken cancellationToken)
        {
            var estateTypeEntity = await CheckerForEstateType.CheckIfEstateTypeExistAndReturnIt(_repositoryManager, request.EstateTypeId, request.TrackChanges);

            _repositoryManager.EstateType.DeleteEstateType(estateTypeEntity);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
