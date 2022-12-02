namespace IvanRealEstate.Application.Handlers.CityHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
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
            var city = await _repositoryManager.City.GetCityAsync(request.CityId, request.TrackChanges);

            if (city is null)
                throw new CityNotFoundException(request.CityId);

            var cityDto = _mapper.Map<CityDto>(city);

            return cityDto;
        }
    }
}
