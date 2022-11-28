namespace Application.Handlers.CityHandlers
{
    using Application.Commands.CityCommands;
    using AutoMapper;
    using Contracts;
    using Entities.Exceptions;
    using MediatR;

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
