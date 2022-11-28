namespace Application.Handlers.CountryHandlers
{
    using Application.Queries.CountryQueries;
    using AutoMapper;
    using Contracts;
    using Entities.Exceptions;
    using MediatR;
    using Shared.DataTransferObject.Country;

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
            var countryEntity = await _repositoryManager.Country.GetCountryAsync(request.CountryId, request.TrackChanges);
            if (countryEntity is null)
                throw new CountryNotFoundException(request.CountryId);

            var countryForReturn = _mapper.Map<CountryDto>(countryEntity);

            return countryForReturn;
        }
    }
}
