namespace IvanRealEstate.Application.Handlers.CityHandlers
{
    using IvanRealEstate.Application.Commands.CityCommands;
    using AutoMapper;
    using Contracts;
    using Entities.Models;
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.City;

    public sealed class CreateCityHandler:IRequestHandler<CreateCityCommand,CityDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateCityHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<CityDto> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var cityEntity = _mapper.Map<City>(request.CityForCreationDto);

            _repositoryManager.City.CreateCity(cityEntity);

            await _repositoryManager.SaveAsync();

            var cityDto = _mapper.Map<CityDto>(cityEntity);

            return cityDto;
        }
    }
}
