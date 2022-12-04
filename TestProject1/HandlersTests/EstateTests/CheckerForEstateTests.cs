namespace IvanRealEstate.Test.HandlersTests.EstateTests
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Application.Handlers.EstateHandlers;

    public class CheckerForEstateTests
    {
        private readonly Guid _estateId;
        private readonly Guid _estateInvalidId;
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly Mock<IRepositoryManager> _mockRepoForInvaliEstateId;

        public CheckerForEstateTests()
        {
            _estateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670");
            _mockRepo = MockEstateRepository.EstateRepositoryForTest(_estateId);

            _estateInvalidId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038679");
            _mockRepoForInvaliEstateId = MockEstateRepository
                .EstateRepositoryForTest(_estateInvalidId);
        }

        [Fact]
        public async Task Valid_CheckIfEstateExist_Test()
        {
            var result = await CheckerForEstate
                .CheckIfEstateExistAndReturnIt(_mockRepo.Object, _estateId, false);

            Assert.IsType<Estate>(result);        
        }

        [Fact]
        public async Task Invalid_CheckIfEstateExist_Test()
        {
            await Assert.ThrowsAsync<EstateNotFoundException>(() => CheckerForEstate
            .CheckIfEstateExistAndReturnIt(_mockRepoForInvaliEstateId.Object, _estateInvalidId, false));
        }
    }
}
