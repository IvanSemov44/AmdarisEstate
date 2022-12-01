using AutoMapper;
using IvanRealEstate.Application.Handlers.CityHandlers;
using IvanRealEstate.Application.Queries.CityQueties;
using IvanRealEstate.Contracts;
using IvanRealEstate.Shared.DataTransferObject.City;
using IvanRealEstate.Test.Mocks;
using Moq;
using Shouldly;

namespace IvanRealEstate.Test.CityTests
{
    public class GetCitiesHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetCitiesHandlerTests()
        {
            _mockRepo = MockCityRepositories.GetCityRepository();

            var mapperCongig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperCongig.CreateMapper();
        }

        [Fact]
        public async Task GetCitiesLiskTest()
        {
            var handler = new GetCitiesHandler(_mockRepo.Object,_mapper);

            var result = await handler.Handle(new GetCitiesQuery(false), CancellationToken.None);

            result.ShouldBeOfType<List<CityDto>>();
            result.Count().ShouldBe(3);
        }
    }
}
