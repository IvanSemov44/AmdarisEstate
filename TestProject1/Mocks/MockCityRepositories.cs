using IvanRealEstate.Contracts;
using IvanRealEstate.Entities.Models;
using Moq;

namespace IvanRealEstate.Test.Mocks
{
    public static class MockCityRepositories
    {
        public static Mock<IRepositoryManager> GetCityRepository()
        {
            var cities = new List<City>
            {
                new City
                {
                    CityId = new Guid(),
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

            mockRepo.Setup(r => r.City.GetCitiesAsync(false)).ReturnsAsync(cities);

            mockRepo.Setup(r => r.City.CreateCity(It.IsAny<City>()));

            return mockRepo;
        }
    }
}
