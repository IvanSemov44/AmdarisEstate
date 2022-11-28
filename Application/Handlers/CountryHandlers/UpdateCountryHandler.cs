namespace IvanRealEstate.Application.Handlers.CountryHandlers
{
    using Application.Commands.CountryCommands;
    using AutoMapper;
    using Contracts;
    using Entities.Exceptions;
    using MediatR;

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
            var countryEntity = await _repositoryManager.Country.GetCountryAsync(request.CountryId, request.TrackChanges);
            if (countryEntity is null)
                throw new CountryNotFoundException(request.CountryId);

            _mapper.Map(request.CountryForUpdateDto, countryEntity);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
