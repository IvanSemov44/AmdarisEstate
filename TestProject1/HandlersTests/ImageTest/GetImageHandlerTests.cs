namespace IvanRealEstate.Test.HandlersTests.ImageTest
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using IvanRealEstate.Application.Queries.ImageQuery;
    using IvanRealEstate.Application.Handlers.ImageHandlers;

    public class GetImageHandlerTests
    {
        private readonly Guid _estateId;
        private readonly Guid _imageId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetImageHandlerTests()
        {
            _imageId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6");
            _estateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670");
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockImageRepository.ImageRepositoryForTest(_estateId, _imageId);
        }

        [Fact]
        public async Task Valid_GetImageHandler_Test()
        {
            var handler = new GetImageHandler(_mapper, _mockRepo.Object);
            var result = await handler
                .Handle(new GetImageQuery(_estateId, _imageId,false),CancellationToken.None);
       
            Assert.NotNull(result);
            Assert.IsType<ImageDto>(result);
            Assert.True("https://pixabay.com/images/search/real%20estate/" == result.ImageUrl);
        }
    }
}
