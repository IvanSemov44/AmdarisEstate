namespace IvanRealEstate.Test.HandlersTests.CountryTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Country;
    using IvanRealEstate.Application.Queries.CountryQueries;
    using IvanRealEstate.Application.Handlers.CountryHandlers;

    public class GetCountryHandlerTest
    {
        private readonly Guid _countryId;
        private readonly Guid _incorrectCountryId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetCountryHandlerTest()
        {
            _countryId = Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656");
            _incorrectCountryId = Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620655");
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockCountryRepository.GetCountryRespository(_countryId);
        }

        [Fact]
        public async Task Valid_GetContryHandlerTest()
        {
            var handler = new GetCountryHandler(_mockRepo.Object, _mapper);
            var result = await handler
                .Handle(new GetCountryQuery(_countryId, TrackChanges: false),CancellationToken.None);


            Assert.NotNull(result);
            Assert.Contains("Bulgaria", result.CountryName);
            Assert.IsType<CountryDto>(result);
        }
    }
}
