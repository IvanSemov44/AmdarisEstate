namespace IvanRealEstate.Test.HandlersTests.CountryTests
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;

    public static class MockCountryRepository
    {
        private static List<Country> countries = new()
            {
                new Country
                {
                    CountryId = Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656"),
                    CountryName = "Bulgaria"
                },
                new Country
                {
                    CountryId = Guid.NewGuid(),
                    CountryName = "Romania"
                },
                new Country
                {
                    CountryId = Guid.NewGuid(),
                    CountryName = "England"
                }
            };

        public static Mock<IRepositoryManager> GetCountryRespository(Guid countryId)
        {
            var mockRepo = new Mock<IRepositoryManager>();

            var country = countries.Where(c => c.CountryId == countryId).SingleOrDefault();

            mockRepo.Setup(r => r.Country.GetCountryAsync(countryId, It.IsAny<bool>()))
                .ReturnsAsync(country);

            mockRepo.Setup(r => r.Country.CreateCountry(It.IsAny<Country>()));

            mockRepo.Setup(r => r.Country.DeleteCountry(It.IsAny<Country>())).Verifiable();

            return mockRepo;
        }

        public static Mock<IRepositoryManager> GetCountryRespository()
        {
            var mockRepo = new Mock<IRepositoryManager>();

            mockRepo.Setup(r => r.Country.GetCountriesAsync(It.IsAny<bool>()))
                .ReturnsAsync(countries);

            return mockRepo;
        }
    }
}
