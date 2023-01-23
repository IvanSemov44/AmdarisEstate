namespace IvanRealEstate.Test.CityTests
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.CityHandlers;
    using IvanRealEstate.Entities.Exceptions.NotFound;

    public class CheckerForCityTest
    {
        private readonly Guid _cityId;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public CheckerForCityTest()
        {
            _cityId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6");

            _mockRepo = MockCityRepository.GetCitiesRepository(_cityId);
        }

        [Fact]
        public async Task Valid_CheckIfCityExist_Test()
        {
            var result = await CheckerForCity.CheckIfCityExistAndReturnIt(_mockRepo.Object, _cityId, false);

            Assert.NotNull(result);
        }

        [Fact]
        public  void InValid_CheckIfCityExcest_Test()
        {
            var id = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b7");

            Assert.ThrowsAsync<CityNotFoundException>(() => 
            CheckerForCity.CheckIfCityExistAndReturnIt(_mockRepo.Object, id, false));
        }
    }
}
