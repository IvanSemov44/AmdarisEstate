namespace IvanRealEstate.Application.Handlers.CountryHandlers
{
    using Application.Queries.CountryQueries;
    using AutoMapper;
    using Contracts;
    using MediatR;
    using Shared.DataTransferObject.Country;

    public sealed class GetCountriesHandler : IRequestHandler<GetCountriesQuiry, IEnumerable<CountryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetCountriesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<CountryDto>> Handle(GetCountriesQuiry request, CancellationToken cancellationToken)
        {
            var countries = await _repositoryManager.Country.GetCountriesAsync(request.TrackChanges);

            var countriesForReturn = _mapper.Map<IEnumerable<CountryDto>>(countries);

            return countriesForReturn;
        }
    }
}
