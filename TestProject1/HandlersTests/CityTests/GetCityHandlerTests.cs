namespace IvanRealEstate.Test.CityTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.City;
    using IvanRealEstate.Application.Queries.CityQueties;
    using IvanRealEstate.Application.Handlers.CityHandlers;

    public class GetCityHandlerTests
    {
        private readonly Guid _cityId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetCityHandlerTests()
        {
            _cityId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6");

            _mockRepo = MockCityRepository.GetCitiesRepository(_cityId);

            var mapperCongig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperCongig.CreateMapper();

        }

        [Fact]
        public async Task Valid_GetCity_Test()
        {
            var handler = new GetCityHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCityQuery(_cityId, false), CancellationToken.None);

            Assert.Contains("Varna", result.CityName);
            Assert.IsType<CityDto>(result);
        }
    }
}
