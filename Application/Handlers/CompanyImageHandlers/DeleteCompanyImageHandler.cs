namespace IvanRealEstate.Application.Handlers.CompanyImageHandlers
{
    using MediatR;
    using IvanRealEstate.Contracts;

    using IvanRealEstate.Application.Handlers.CompanyHandlers;
    using IvanRealEstate.Application.Commands.CompanyImageCommands;

    public sealed class DeleteCompanyImageHandler : IRequestHandler<DeleteCompanyImageCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteCompanyImageHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(DeleteCompanyImageCommand request, CancellationToken cancellationToken)
        {
            await CheckerForCompany.CheckIfCompanyExistAndReturnIt(_repositoryManager, request.CompanyId, request.TrackChanges);

            var image = await CheckerForCompanyImage.CheckIfCompanyImageExistAndReturnIt(_repositoryManager, request.CompanyId, request.CompanyImageId, request.TrackChanges);

            _repositoryManager.CompanyImage.DeleteCompanyImage(image);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
