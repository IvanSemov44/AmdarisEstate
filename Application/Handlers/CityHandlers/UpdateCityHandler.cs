namespace IvanRealEstate.Application.Handlers.CityHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.CityCommands;

    public sealed class UpdateCityHandler : IRequestHandler<UpdateCityCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateCityHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await CheckerForCity.CheckIfCityExistAndReturnIt(_repositoryManager, request.CityId, request.TrackChanges);

            _mapper.Map(request.CityForUpdateDto, city);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
