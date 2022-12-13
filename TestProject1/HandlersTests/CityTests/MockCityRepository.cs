namespace IvanRealEstate.Test.CityTests
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;

    public static class MockCityRepository
    {
        public static Mock<IRepositoryManager> GetCitiesRepository(Guid cityId)
        {
            var cities = new List<City>
            {
                new City
                {
                    CityId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6"),
                    CityName = "Varna"
                },
                new City
                {
                     CityId = new Guid(),
                     CityName = "Sofia"
                },
                new City
                {
                    CityId = new Guid(),
                    CityName = "Plovdiv"
                },
            };

            var mockRepo = new Mock<IRepositoryManager>();

            var city = cities.Where(c => c.CityId == cityId).SingleOrDefault();

            mockRepo.Setup(r => r.City.GetCitiesAsync(It.IsAny<bool>())).ReturnsAsync(cities);

            mockRepo.Setup(r => r.City.GetCityAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(city);

            mockRepo.Setup(r => r.City.CreateCity(It.IsAny<City>()));

            mockRepo.Setup(r => r.City.DeleteCity(It.IsAny<City>())).Verifiable();

            return mockRepo;
        }
        public static Mock<IRepositoryManager> GetCitiesRepository()
        {
            var cities = new List<City>
            {
                new City
                {
                    CityId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6"),
                    CityName = "Varna"
                },
                new City
                {
                     CityId = new Guid(),
                     CityName = "Sofia"
                },
                new City
                {
                    CityId = new Guid(),
                    CityName = "Plovdiv"
                },
            };

            var mockRepo = new Mock<IRepositoryManager>();

            //var city = cities.Where(c => c.CityId == cityId).SingleOrDefault();

            mockRepo.Setup(r => r.City.GetCitiesAsync(false)).ReturnsAsync(cities);

            //mockRepo.Setup(r => r.City.GetCityAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
            //    .ReturnsAsync(city);

            mockRepo.Setup(r => r.City.CreateCity(It.IsAny<City>()));

            mockRepo.Setup(r => r.City.DeleteCity(It.IsAny<City>()));

            return mockRepo;
        }
    }
}
