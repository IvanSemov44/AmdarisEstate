namespace IvanRealEstate.Test.HandlersTests.ImageTest
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using IvanRealEstate.Application.Commands.ImageCommads;
    using IvanRealEstate.Application.Handlers.ImageHandlers;

    public class CreateImageHandlerTests
    {
        private readonly Guid _estateId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly ImageForCreationDto _imageForCreationDto;

        public CreateImageHandlerTests()
        {
            _estateId = Guid.NewGuid();
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockImageRepository.ImageRepositoryForTest();

            _imageForCreationDto = new ImageForCreationDto
            {
                ImageUrl = "https://www.images.com"
            };
        }

        [Fact]
        public async Task Valid_CreateImageHandler_Test()
        {
            var handler = new CreateImageHandler(_mockRepo.Object, _mapper);

            var result = await handler
                .Handle(new CreateImageCommand(
                    _estateId, _imageForCreationDto, false), CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<ImageDto>(result);
            Assert.True("https://www.images.com" == result.ImageUrl);
        }
    }
}
