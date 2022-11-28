namespace IvanRealEstate.Application.Handlers.CityHandlers
{
    using AutoMapper;
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Application.Commands.CityCommands;

    public sealed class DeleteCityHandler : IRequestHandler<DeleteCityCommand, Unit>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public DeleteCityHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _repositoryManager.City.GetCityAsync(request.Id, request.TrackChanges);
            if (city is null)
                throw new CityNotFoundException(request.Id);

            _repositoryManager.City.DeleteCity(city);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
