namespace IvanRealEstate.Test.HandlersTests.EstateTypeTests
{
    using Moq;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.EstateTypeHandler;
    using IvanRealEstate.Application.Commands.EstateTypeCommands;

    public class DeleteEstateTypeHandlerTest
    {
        private readonly Guid _estateTypeId;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public DeleteEstateTypeHandlerTest()
        {
            _estateTypeId = Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662");
            _mockRepo = MockEstateTypeRepository.EstateTypeRepository(_estateTypeId);
        }

        [Fact]
        public async Task Valid_DeleteEstateTypeHandlerTest()
        {
            await new DeleteEstateTypeHandler(_mockRepo.Object)
               .Handle(new DeleteEstateTypeCommand(_estateTypeId, TrackChanges: false),
               CancellationToken.None);

            _mockRepo.Verify();
        }
    }
}
