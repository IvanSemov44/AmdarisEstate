namespace IvanRealEstate.Test.HandlersTests.ImageTest
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Application.Handlers.ImageHandlers;

    public class CheckerForImageTests
    {
        private readonly Guid _imageId;
        private readonly Guid _imageInvalidId;
        private readonly Mock<IRepositoryManager> _mockRepo;

        private readonly Guid _estateId;
        private readonly Mock<IRepositoryManager> _mockRepoForInvalidIds;

        public CheckerForImageTests()
        {
            _imageId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6");
            _estateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670");
            _mockRepo = MockImageRepository.ImageRepositoryForTest(_estateId, _imageId);

            _imageInvalidId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b5");
            _mockRepoForInvalidIds = MockImageRepository.ImageRepositoryForTest(_estateId, _imageInvalidId);
        }

        [Fact]
        public async Task Valid_CheckerForImage_Test()
        {
            var result = await CheckerForImage
                .CheckIfImageExistAndReturnIt(_mockRepo.Object, _estateId, _imageId, false);

            Assert.IsType<Image>(result);
        }

        [Fact]
        public async Task InValid_CheckerForImage_Test()
        {
           await Assert.ThrowsAsync<ImageNotFoundException>(async ()=>
           await CheckerForImage
                .CheckIfImageExistAndReturnIt(_mockRepoForInvalidIds.Object, _estateId, _imageInvalidId, false));
        }

    }
}
