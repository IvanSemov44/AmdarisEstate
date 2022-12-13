namespace IvanRealEstate.Test.HandlersTests.CountryTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Country;
    using IvanRealEstate.Application.Commands.CountryCommands;
    using IvanRealEstate.Application.Handlers.CountryHandlers;

    public class UpdateCountryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly Guid _countryId;
        private readonly CountryForUpdateDto _countryForUdpate;

        public UpdateCountryHandlerTest()
        {
            _countryId = Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656");
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockCountryRepository.GetCountryRespository(_countryId);

            _countryForUdpate = new CountryForUpdateDto
            {
                CountryName = "Macedonia",
            };
        }

        [Fact]
        public async Task Valid_UpdateCoutrnyHandlerTest()
        {
            var handler = new UpdateCountryHandler(_mockRepo.Object, _mapper);
            await handler
                 .Handle(new UpdateCountryCommand(_countryId, _countryForUdpate, TrackChanges: true),
                 CancellationToken.None);

            var result = await _mockRepo.Object.Country.GetCountryAsync(_countryId, trackChanges: false);

            Assert.True(result?.CountryName == _countryForUdpate.CountryName);
            Assert.False(result?.CountryName == _countryForUdpate.CountryName?.Substring(2));
        }
    }
}
