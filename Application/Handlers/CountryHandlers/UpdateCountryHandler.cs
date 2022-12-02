namespace IvanRealEstate.Application.Handlers.CountryHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.CountryCommands;

    public sealed class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, Unit>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateCountryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var countryEntity =  await CheckerForCountry.CheckIfCountryExistAndReturnIt(_repositoryManager, request.CountryId, request.TrackChanges);

            _mapper.Map(request.CountryForUpdateDto, countryEntity);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
