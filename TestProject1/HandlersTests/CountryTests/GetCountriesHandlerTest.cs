namespace IvanRealEstate.Test.HandlersTests.CountryTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Country;
    using IvanRealEstate.Application.Queries.CountryQueries;
    using IvanRealEstate.Application.Handlers.CountryHandlers;

    public class GetCountriesHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetCountriesHandlerTest()
        {
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockCountryRepository.GetCountryRespository();
        }

        [Fact]
        public async Task Valid_GetCountries_Test()
        {
            var handler = new GetCountriesHandler(_mockRepo.Object, _mapper);
            var result =await handler.Handle(new GetCountriesQuery(TrackChanges:false),CancellationToken.None);
            
            Assert.NotNull(result);
            Assert.IsAssignableFrom<List<CountryDto>>(result);

            Assert.True(result.Count() == 3);
        }

        [Fact]
        public async Task InValid_GetCountries_Test()
        {
            var handler = new GetCountriesHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetCountriesQuery(TrackChanges: false), CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<List<CountryDto>>(result);

            Assert.False(result.Count() == 4);
        }
    }
}
