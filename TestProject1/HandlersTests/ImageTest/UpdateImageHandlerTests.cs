namespace IvanRealEstate.Test.HandlersTests.ImageTest
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using IvanRealEstate.Application.Commands.ImageCommads;
    using IvanRealEstate.Application.Handlers.ImageHandlers;

    public class UpdateImageHandlerTests
    {
        private readonly Guid _estateId;
        private readonly Guid _imageId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly ImageForUpdateDto _imageForUpdateDto;

        public UpdateImageHandlerTests()
        {
            _estateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670");
            _imageId = Guid.Parse("a7811775-1316-4e2c-4241-08dad234d5b6");
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockImageRepository.ImageRepositoryForTest(_estateId,_imageId);

            _imageForUpdateDto = new ImageForUpdateDto
            {
                ImageUrl = "https://www.newpic.code"
            };
        }

        [Fact]
        public async Task Valid_UpdateImageHandler_Test()
        {
            var handler = new UpdateImageHandler(_mockRepo.Object, _mapper);
            await handler.Handle(new UpdateImageCommand(
                _estateId,_imageId,_imageForUpdateDto,false,true), CancellationToken.None);

            var result = await _mockRepo.Object.Image.GetImageAsync(_estateId, _imageId, false);

            Assert.True(result?.ImageUrl == _imageForUpdateDto.ImageUrl);
        }
    }
}
