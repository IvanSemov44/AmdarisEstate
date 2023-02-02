namespace IvanRealEstate.Test.HandlersTests.CountryTests
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.CountryHandlers;
    using IvanRealEstate.Entities.Exceptions.NotFound;

    public class CheckerForCountryTest
    {
        private readonly Guid _countryId;
        private readonly Guid _invalidCountryId;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public CheckerForCountryTest()
        {
            _countryId = Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656");
            _invalidCountryId = Guid.NewGuid();
            _mockRepo = MockCountryRepository.GetCountryRespository(_countryId);
        }

        [Fact]
        public void Valid_CheckerForCountryTest()
        {   
            var result = CheckerForCountry
                .CheckIfCountryExistAndReturnIt(_mockRepo.Object, _countryId, trackChanges: false);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Invalid_CheckerForCountryTest()
        {
            await Assert.ThrowsAsync<CountryNotFoundException>(() =>CheckerForCountry
             .CheckIfCountryExistAndReturnIt(_mockRepo.Object, _invalidCountryId, trackChanges: false));
        }
    }
}
