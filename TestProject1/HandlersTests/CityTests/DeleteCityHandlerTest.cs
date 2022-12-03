namespace IvanRealEstate.Test.CityTests
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.CityCommands;
    using IvanRealEstate.Application.Handlers.CityHandlers;

    public class DeleteCityHandlerTest
    {
        private readonly Guid _cityId;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public DeleteCityHandlerTest()
        {
            _cityId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6");

            _mockRepo = MockCityRepository.GetCitiesRepository(_cityId);
        }

        [Fact]
        public async Task Valid_DeleteCity_Test()
        {
            var handler = new DeleteCityHandler(_mockRepo.Object);

            await handler.Handle(new DeleteCityCommand(_cityId, false),CancellationToken.None);

            _mockRepo.Verify();
        }
    }
}
