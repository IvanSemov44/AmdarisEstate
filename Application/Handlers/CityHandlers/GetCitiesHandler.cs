namespace IvanRealEstate.Application.Handlers.CityHandlers
{
    using AutoMapper;
    using Contracts;
    using IvanRealEstate.Application.Queries.CityQueties;
    using MediatR;
    using Shared.DataTransferObject.City;

    public sealed class GetCitiesHandler : IRequestHandler<GetCitiesQuery, IEnumerable<CityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetCitiesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<CityDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await _repositoryManager.City.GetCitiesAsync(request.TrackChanges);
            var citiesForReturn = _mapper.Map<IEnumerable<CityDto>>(cities);

            return citiesForReturn;
        }
    }
}
