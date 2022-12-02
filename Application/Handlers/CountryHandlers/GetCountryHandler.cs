namespace IvanRealEstate.Application.Handlers.CountryHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Country;
    using IvanRealEstate.Application.Queries.CountryQueries;

    public sealed class GetCountryHandler : IRequestHandler<GetCountryQuery, CountryDto>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetCountryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<CountryDto> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            var countryEntity = await CheckerForCountry.CheckIfCountryExistAndReturnIt(_repositoryManager, request.CountryId, request.TrackChanges);

            var countryForReturn = _mapper.Map<CountryDto>(countryEntity);

            return countryForReturn;
        }
    }
}
