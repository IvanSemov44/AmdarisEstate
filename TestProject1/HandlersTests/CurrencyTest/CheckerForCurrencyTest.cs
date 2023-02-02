namespace IvanRealEstate.Test.HandlersTests.CurrencyTest
{
    using Moq;
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.CurrencyHandlers;
    using IvanRealEstate.Entities.Exceptions.NotFound;

    public class CheckerForCurrencyTest
    {
        private readonly Guid _currencyId;
        private readonly Guid _invalidCurrency;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public CheckerForCurrencyTest()
        {
            _invalidCurrency = Guid.NewGuid();
            _currencyId = Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0");
            _mockRepo = MockCurrencyRepository.CurrencyRepositoryForTest();
        }

        [Fact]
        public void Valid_CheckerForCurrencyTest()
        {
            var result = CheckerForCurrency
                .CheckIfCurrencyExistAndReturnIt(_mockRepo.Object, _currencyId, trackChanges: false);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Invalid_CheckerForCurrencyTest()
        {
            await Assert.ThrowsAsync<CurrencyNotFoundException>(() => CheckerForCurrency
            .CheckIfCurrencyExistAndReturnIt(_mockRepo.Object, _invalidCurrency, trackChanges: false));
        }
    }
}
