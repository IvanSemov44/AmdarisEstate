namespace IvanRealEstate.Test.HandlersTests.EstateTests
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Application.Commands.EstateCommands;
    using IvanRealEstate.Application.Handlers.EstateHandlers;

    public class DeleteEstateHandlerTests
    {
        private readonly Guid _estateId;
        private readonly Guid _invalidEstateId;

        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly Mock<IRepositoryManager> _mockRepoForInvalid;

        public DeleteEstateHandlerTests()
        {
            _estateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670");
            _mockRepo = MockEstateRepository.EstateRepositoryForTest(_estateId);

            _invalidEstateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038679");
            _mockRepoForInvalid = MockEstateRepository.EstateRepositoryForTest(_invalidEstateId);
        }

        [Fact]
        public async Task Valid_DeleteEstate_Test()
        {
            var handler = new DeleteEstateHandler(_mockRepo.Object);
            await handler.Handle(new DeleteEstateCommand(_estateId, false), CancellationToken.None);

            _mockRepo.Verify();
        }

        [Fact]
        public async Task UnValidEstateId_DeleteEstateHandler_Test()
        {
            var handler = new DeleteEstateHandler(_mockRepoForInvalid.Object);

            await Assert.ThrowsAnyAsync<EstateNotFoundException>
                (() => handler.Handle(new DeleteEstateCommand(_estateId, false), CancellationToken.None));
        }
    }
}
