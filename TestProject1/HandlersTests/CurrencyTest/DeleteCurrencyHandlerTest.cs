namespace IvanRealEstate.Test.HandlersTests.CurrencyTest
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.CurrencyHandlers;
    using IvanRealEstate.Application.Commands.CurrencyCommands;

    public class DeleteCurrencyHandlerTest
    {
        private readonly Guid _currencyId;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public DeleteCurrencyHandlerTest()
        {
            _currencyId = Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0");
            _mockRepo = MockCurrencyRepository.CurrencyRepositoryForTest(_currencyId);
        }

        [Fact]
        public async Task Valid_DeleteCurrencyHandlerTest()
        {
            var handler = new DeleteCurrencyHandler(_mockRepo.Object);
            await handler.Handle(new DeleteCurrencyCommand(_currencyId, TrackChanges: false),
                CancellationToken.None);

            _mockRepo.Verify();
        }
    }
}
