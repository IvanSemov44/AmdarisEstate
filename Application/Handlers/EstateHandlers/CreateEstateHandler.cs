namespace Application.Handlers.EstateHandlers
{
    using Application.Commands.EstateCommands;
    using AutoMapper;
    using Contracts;
    using Entities.Models;
    using MediatR;
    using Shared.DataTransferObject.Estate;

    public sealed class CreateEstateHandler : IRequestHandler<CreateEstateCommand, EstateDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateEstateHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<EstateDto> Handle(CreateEstateCommand request, CancellationToken cancellationToken)
        {
            var estateEntity = _mapper.Map<Estate>(request.EstateForCreationDto);

            //var currencyName = estateEntity.CurencyId.ToString();
            //var countryName = estateEntity.CountryId.ToString();
            //var cityName = estateEntity.CityId.ToString();
            //var typeName = estateEntity.EstateTypeId.ToString();

            //var curency = await _repositoryManager.Curency.GetCurencyByNameAsync(currencyName, trackChanges: false);
            //if (curency is null)
            //{
            //    var curencyForCreate = new Curency();
            //    curencyForCreate.CurencyName = currencyName;

            //    _repositoryManager.Curency.CreateCurency(curencyForCreate);
            //    await _repositoryManager.SaveAsync();

            //    var curencyFromDb = await _repositoryManager.Curency.GetCurencyByNameAsync(currencyName, trackChanges: false);

            //    estateEntity.CurencyId = curencyFromDb.CurencyId;
            //}
            //else
            //{
            //    estateEntity.CurencyId = curency.CurencyId;
            //}

            //var country = await _repositoryManager.Country.GetCountryByNameAsync(countryName, trackChanges: false);
            //if (country is null)
            //{
            //    var counryForCreate = new Country();
            //    counryForCreate.CountryName = countryName;
            //    _repositoryManager.Country.CreateCountry(counryForCreate);
            //    await _repositoryManager.SaveAsync();

            //    var countryFromDb = await _repositoryManager.Country.GetCountryByNameAsync(countryName, trackChanges: false);
            //    estateEntity.CountryId = countryFromDb.CountryId;
            //}
            //else
            //{
            //    estateEntity.CountryId = country.CountryId;
            //}

            //var city = await _repositoryManager.City.GetCityByNameAsync(cityName, trackChanges: false);
            //if (city is null)
            //{
            //    var cityForCreate = new City();
            //    cityForCreate.CityName = cityName;
            //    _repositoryManager.City.CreateCity(cityForCreate);
            //    await _repositoryManager.SaveAsync();

            //    var cityFromDb = await _repositoryManager.City.GetCityByNameAsync(cityName, trackChanges: false);
            //    estateEntity.CityId = cityFromDb.CityId;
            //}
            //else
            //{
            //    estateEntity.CityId = city.CityId;
            //}

            //var type = await _repositoryManager.EstateType.GetEstateTypeByNameAsync(typeName, trackChanges: false);
            //if(type is null)
            //{
            //    var typeForCreate = new EstateType();
            //    typeForCreate.TypeName = typeName;
            //    _repositoryManager.EstateType.CreateEstateType(typeForCreate);
            //    await _repositoryManager.SaveAsync();

            //    var typeFromDb = await _repositoryManager.EstateType.GetEstateTypeByNameAsync(typeName, trackChanges: false);
            //    estateEntity.EstateTypeId = typeFromDb.EstateTypeId;
            //}
            //else
            //{
            //    estateEntity.EstateTypeId = type.EstateTypeId;
            //}

            //estateEntity.Created = DateTime.UtcNow;
            //estateEntity.Changed = DateTime.UtcNow;

            //_repositoryManager.Estate.CreateEstate();

            throw new NotImplementedException();
        }
    }
}
