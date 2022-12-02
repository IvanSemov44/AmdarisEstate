namespace IvanRealEstate.Application.Handlers.CountryHandlers
{
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.CountryCommands;

    public sealed class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteCountryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await CheckerForCountry.CheckIfCountryExistAndReturnIt(_repositoryManager, request.CountryId, request.TrackChanges);

            _repositoryManager.Country.DeleteCountry(country);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
