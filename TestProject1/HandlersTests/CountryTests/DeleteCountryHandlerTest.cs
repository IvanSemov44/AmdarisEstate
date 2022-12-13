namespace IvanRealEstate.Test.HandlersTests.CountryTests
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.CountryCommands;
    using IvanRealEstate.Application.Handlers.CountryHandlers;

    public class DeleteCountryHandlerTest
    {
        private readonly Guid _countryId;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public DeleteCountryHandlerTest()
        {
            _countryId = Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656");
            _mockRepo = MockCountryRepository.GetCountryRespository(_countryId);
        }

        [Fact]
        public async Task Valid_DeleteCountryHandlerTest()
        {
            var handler = new DeleteCountryHandler(_mockRepo.Object);
            await handler.Handle(new DeleteCountryCommand(_countryId, TrackChanges: false),
                CancellationToken.None);

            _mockRepo.Verify();
        }
    }
}
