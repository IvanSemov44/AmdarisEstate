using IvanRealEstate.Application.Commands.ImageCommads;
using IvanRealEstate.Application.Handlers.ImageHandlers;
using IvanRealEstate.Contracts;
using Moq;

namespace IvanRealEstate.Test.HandlersTests.ImageTest
{
    public class DeleteImageHandlerTests
    {
        private readonly Guid _estateId;
        private readonly Guid _imageId;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public DeleteImageHandlerTests()
        {
            _estateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670");
            _imageId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6");
            _mockRepo = MockImageRepository.ImageRepositoryForTest(_estateId,_imageId);
        }

        [Fact]
        public async Task Valid_DeleteImageHandler_Test()
        {
            var handler = new DeleteImageHandler(_mockRepo.Object);
            await handler.Handle(new DeleteImageCommand(_estateId, _imageId, false),CancellationToken.None);

            _mockRepo.Verify();
        }
    }
}
