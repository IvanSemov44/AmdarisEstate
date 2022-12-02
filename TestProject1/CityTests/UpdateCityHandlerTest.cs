namespace IvanRealEstate.Test.CityTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.City;
    using IvanRealEstate.Application.Handlers.CityHandlers;
    using IvanRealEstate.Application.Commands.CityCommands;

    public  class UpdateCityHandlerTest
    {
        private readonly Guid _cityId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly CityForUpdateDto _cityForUpdateDto;

        public UpdateCityHandlerTest()
        {
            _cityId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6");

            _mockRepo = MockCityRepository.GetCitiesRepository(_cityId);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _cityForUpdateDto = new CityForUpdateDto
            {
                CityName = "Sofia"
            };
        }

        [Fact]
        public async Task Valid_UpdateCity_Test()
        {
            var handler = new UpdateCityHandler(_mockRepo.Object,_mapper);

            var result = handler.Handle(new UpdateCityCommand(_cityId, _cityForUpdateDto, true),CancellationToken.None);

            var resultfromDB = await _mockRepo.Object.City.GetCityAsync(_cityId, false);

            Assert.True(_cityForUpdateDto.CityName == resultfromDB?.CityName);
        }
    }
}
