namespace IvanRealEstate.Test.HandlersTests.CurrencyTest
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;

    public static class MockCurrencyRepository
    {
        private static List<Currency> currencies = new()
        {
            new Currency
            {
                CurrencyId = Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0"),
                CurrencyName = "Euro"
            },
            new Currency
            {
                CurrencyId = Guid.NewGuid(),
                CurrencyName = "Lev"
            },
            new Currency
            {
                CurrencyId = Guid.NewGuid(),
                CurrencyName = "Lei"
            }
        };

        public static Mock<IRepositoryManager> CurrencyRepositoryForTest(Guid currencyId)
        {
            var mockRepo = new Mock<IRepositoryManager>();

            var currency = currencies.Where(c => c.CurrencyId == currencyId).SingleOrDefault();

            mockRepo.Setup(c => c.Currency.GetCurrencyAsync(currencyId, It.IsAny<bool>()))
                .ReturnsAsync(currency);

            mockRepo.Setup(c => c.Currency.CreateCurrency(It.IsAny<Currency>()));

            mockRepo.Setup(c => c.Currency.DeleteCurrency(It.IsAny<Currency>())).Verifiable();

            mockRepo.Setup(c => c.SaveAsync()).Verifiable();

            return mockRepo;
        }

        public static Mock<IRepositoryManager> CurrencyRepositoryForTest()
        {
            var mockRepo = new Mock<IRepositoryManager>();

            mockRepo.Setup(c => c.Currency.GetCurrenciesAsync(It.IsAny<bool>()))
                .ReturnsAsync(currencies);

            return mockRepo;
        }
    }
}
