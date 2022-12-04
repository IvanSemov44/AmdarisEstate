namespace IvanRealEstate.Test.HandlersTests.ImageTest
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using IvanRealEstate.Application.Queries.ImageQuery;
    using IvanRealEstate.Application.Handlers.ImageHandlers;

    public class GetImagesHandlerTests
    {
        private readonly Guid _estateId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetImagesHandlerTests()
        {
            _mapper = MapperConfig.Configuration();
            _estateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670");
            _mockRepo = MockImageRepository.ImageRepositoryForTest();
        }

        [Fact]
        public async Task Valid_GetImageHandler_Test()
        {
            var handler = new GetImagesHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetImagesQuery(_estateId, false), CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.Count() == 3);
            Assert.IsType<List<ImageDto>>(result);
        }
    }
}
