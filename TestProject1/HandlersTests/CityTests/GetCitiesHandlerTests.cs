namespace IvanRealEstate.Test.CityTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.City;
    using IvanRealEstate.Application.Queries.CityQueties;
    using IvanRealEstate.Application.Handlers.CityHandlers;

    public class GetCitiesHandlerTests
    {
        private readonly Guid _cityId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetCitiesHandlerTests()
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
        public async Task Valid_Cities_GetAll_Tests()
        {
            var handler = new GetCitiesHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCitiesQuery(false), CancellationToken.None);

            Assert.IsAssignableFrom<List<CityDto>>(result);
            //Assert.Collection<CityDto>(result, 3);
            Assert.True(result.Count() == 3);
        }
    }
}
