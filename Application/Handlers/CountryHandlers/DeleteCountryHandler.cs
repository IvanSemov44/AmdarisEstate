namespace IvanRealEstate.Application.Handlers.CountryHandlers
{
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
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
            var country = await _repositoryManager.Country.GetCountryAsync(request.CountryId, request.TrackChanges);
            if (country is null)
                throw new CountryNotFoundException(request.CountryId);

            _repositoryManager.Country.DeleteCountry(country);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
