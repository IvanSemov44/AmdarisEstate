namespace IvanRealEstate.Test.HandlersTests.CountryTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Country;
    using IvanRealEstate.Application.Commands.CountryCommands;
    using IvanRealEstate.Application.Handlers.CountryHandlers;

    public class CreateCountryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly CountryForCreationDto _countryForCreationDto;

        public CreateCountryHandlerTest()
        {
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockCountryRepository.GetCountryRespository();

            _countryForCreationDto = new CountryForCreationDto
            {
                CountryName = "Moldova"
            };
        }

        [Fact]
        public async Task Valid_CreateCountryHandlerTest()
        {
            var handler = new CreateCountryHandler(_mockRepo.Object, _mapper);
            var result = await handler
                .Handle(new CreateCountryCommand(_countryForCreationDto),CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<CountryDto>(result);
            Assert.Contains("Moldova", result.CountryName);
        }
    }
}
