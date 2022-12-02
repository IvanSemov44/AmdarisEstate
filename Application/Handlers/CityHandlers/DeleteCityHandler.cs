namespace IvanRealEstate.Application.Handlers.CityHandlers
{
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.CityCommands;

    public sealed class DeleteCityHandler : IRequestHandler<DeleteCityCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteCityHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await CheckerForCity.CheckIfCityExistAndReturnIt(_repositoryManager, request.Id, request.TrackChanges);

            _repositoryManager.City.DeleteCity(city);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
