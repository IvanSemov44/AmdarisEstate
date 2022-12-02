namespace IvanRealEstate.Test.CityTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.City;
    using IvanRealEstate.Application.Commands.CityCommands;
    using IvanRealEstate.Application.Handlers.CityHandlers;

    public class CreteCityCommandHandlerTests
    {
        private readonly Guid _cityId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly CityForCreationDto _cityForCreationDto;

        public CreteCityCommandHandlerTests()
        {

            _cityId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6");
            _mockRepo = MockCityRepository.GetCitiesRepository(_cityId);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _cityForCreationDto = new CityForCreationDto
            {
                CityName = "Sofia"
            };
        }

        [Fact]
        public async Task Valid_City_Created_Test()
        {
            var handler = new CreateCityHandler(_mockRepo.Object, _mapper);

            var result = handler.Handle(new CreateCityCommand(_cityForCreationDto), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Sofia", result.Result.CityName);
            await Assert.IsAssignableFrom<Task<CityDto>>(result);

        }
    }
}
