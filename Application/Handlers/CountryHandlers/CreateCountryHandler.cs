namespace IvanRealEstate.Application.Handlers.CountryHandlers
{
    using Application.Commands.CountryCommands;
    using AutoMapper;
    using Contracts;
    using Entities.Models;
    using MediatR;
    using Shared.DataTransferObject.Country;

    public sealed class CreateCountryHandler : IRequestHandler<CreateCountryCommand, CountryDto>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CreateCountryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<CountryDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var countryEntity = _mapper.Map<Country>(request.CountryForCreationDto);

            _repositoryManager.Country.CreateCountry(countryEntity);

            await _repositoryManager.SaveAsync();

            var countryForReturen = _mapper.Map<CountryDto>(countryEntity);

            return countryForReturen;
        }
    }
}
