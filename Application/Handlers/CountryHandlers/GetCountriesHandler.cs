﻿namespace IvanRealEstate.Application.Handlers.CountryHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Queries.CountryQueries;
    using IvanRealEstate.Shared.DataTransferObject.Country;

    public sealed class GetCountriesHandler : IRequestHandler<GetCountriesQuery, IEnumerable<CountryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetCountriesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _repositoryManager.Country.GetCountriesAsync(request.TrackChanges);

            var countriesForReturn = _mapper.Map<IEnumerable<CountryDto>>(countries);

            return countriesForReturn;
        }
    }
}
