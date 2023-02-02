namespace IvanRealEstate.Test.HandlersTests.EstateTypeTests
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions.NotFound;
    using IvanRealEstate.Application.Handlers.EstateTypeHandler;

    public class CheckerForEstateTypeTest
    {

        private readonly Guid _estateTypeId;
        private readonly Guid _estateTypeInvalidId;
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly Mock<IRepositoryManager> _mockRepoForInvaliEstateTypeId;

        public CheckerForEstateTypeTest()
        {
            _estateTypeId = Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662");
            _mockRepo = MockEstateTypeRepository.EstateTypeRepository(_estateTypeId);

            _estateTypeInvalidId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038679");
            _mockRepoForInvaliEstateTypeId = MockEstateTypeRepository
                .EstateTypeRepository(_estateTypeInvalidId);
        }

        [Fact]
        public async Task Valid_CheckIfEstateExist_Test()
        {
            var result = await CheckerForEstateType
                .CheckIfEstateTypeExistAndReturnIt(_mockRepo.Object, _estateTypeId, false);

            Assert.IsType<EstateType>(result);
        }

        [Fact]
        public async Task Invalid_CheckIfEstateExist_Test()
        {
            await Assert.ThrowsAsync<EstateTypeNotFoundException>(() => CheckerForEstateType
            .CheckIfEstateTypeExistAndReturnIt(_mockRepoForInvaliEstateTypeId.Object, _estateTypeInvalidId, false));
        }
    }
}
