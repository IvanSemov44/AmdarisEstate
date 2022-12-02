namespace IvanRealEstate.Application.Handlers.CityHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.City;
    using IvanRealEstate.Application.Queries.CityQueties;

    public sealed class GetCityHandler : IRequestHandler<GetCityQuery, CityDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetCityHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<CityDto> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var city = await CheckerForCity.CheckIfCityExistAndReturnIt(_repositoryManager,request.CityId, request.TrackChanges);

            var cityDto = _mapper.Map<CityDto>(city);

            return cityDto;
        }
    }
}
