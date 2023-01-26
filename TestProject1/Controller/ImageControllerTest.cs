namespace IvanRealEstate.Test.Controller
{
    using Moq;
    using MediatR;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Presentation.Controllers;
    using IvanRealEstate.Application.Queries.ImageQuery;
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using IvanRealEstate.Application.Commands.ImageCommads;

    public class ImageControllerTest
    {
        private readonly Mock<IMediator> _mockRepo;
        private readonly ImageController _controller;

        public ImageControllerTest()
        {
            _mockRepo = new Mock<IMediator>();
            _controller = new ImageController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetImages_ActionExecute_ReturnOkObjectResultForGetImages()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetImagesQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var guid = Guid.NewGuid();

            var result = await _controller.GetAllImageForEstate(guid);

            _mockRepo.Verify(x => x.Send(It.IsAny<GetImagesQuery>(), It.IsAny<CancellationToken>()));

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetImage_ActionExecute_ReturnExactNumberOfImage()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetImagesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ImageDto>() { new ImageDto(), new ImageDto() });
            
            var guid = Guid.NewGuid();

            var result = await _controller.GetAllImageForEstate(guid);

            var resultObject = Assert.IsType<OkObjectResult>(result);
            var cities = Assert.IsType<List<ImageDto>>(resultObject.Value);
            Assert.Equal(2, cities.Count);
        }

        [Fact]
        public async Task GetImageById_ActionExecute_GetImageQueryIsCalled()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetImageQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var guid = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");
            var guidForEstate = Guid.NewGuid();

            await _controller.GetImageForEstate(guidForEstate,guid);

            _mockRepo.Verify(r => r.Send(It.IsAny<GetImageQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task GetImageById_ActionExecute_GetImageQueryWithCorrectImageIdIsCalled()
        {
            var guid = Guid.NewGuid();

            _mockRepo.Setup(r => r.Send(It.IsAny<GetImageQuery>(), It.IsAny<CancellationToken>()))
                 .Returns<GetImageQuery, CancellationToken>(async (q, c) =>
                 {
                     guid = q.ImageId;
                     return await Task.FromResult(
                         new ImageDto
                         {
                             
                             ImageId = q.ImageId,
                             ImageUrl = "http://estate.com"
                         });
                 });

            var imageId = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");
            var guidForEstate = Guid.NewGuid();

            var result = await _controller.GetImageForEstate(guidForEstate, imageId);

            var resultObjerct = Assert.IsType<OkObjectResult>(result);

            Assert.Equal((int)HttpStatusCode.OK, resultObjerct.StatusCode);
            Assert.Equal("http://estate.com", (resultObjerct.Value as ImageDto)?.ImageUrl);
            Assert.Equal(guid.ToString(), imageId.ToString());
        }

        [Fact]
        public async Task Create_ActionExecure_ReturnCreatedAtRouteResult()
        {
            _mockRepo.Setup(r => r.Send(
                It.IsAny<CreateImageCommand>(),
                It.IsAny<CancellationToken>()))
                  .ReturnsAsync(
                    new ImageDto
                    {
                        ImageId = Guid.NewGuid(),
                        ImageUrl = "http://estate.com"
                    }
                 );

            var currency = new ImageForCreationDto { ImageUrl = "http://estate.com" };

            var guid = Guid.NewGuid();

            var result = await _controller.CreateImageForEstate(guid,currency);

            var resultRouteStatus = (result as CreatedAtRouteResult)?.StatusCode;
            var resultRouteDto = ((result as CreatedAtRouteResult)?.Value as ImageDto);

            Assert.IsType<CreatedAtRouteResult>(result);
            Assert.True((int)HttpStatusCode.Created == resultRouteStatus);
            Assert.True(resultRouteDto?.ImageUrl == currency.ImageUrl);
        }

        [Fact]
        public async Task Update_ActionExecure_ReturnNoContentResult()
        {
            var id = Guid.NewGuid();
            var estateType = new ImageForUpdateDto { ImageUrl = "http://estate.com" };

            var guidEstate = Guid.NewGuid();
            var guidImage = Guid.NewGuid();

            var result = await _controller.UpdateImageForEstate(guidEstate, guidImage, estateType);

            _mockRepo.Verify(r => r.Send(
                It.IsAny<UpdateImageCommand>(),
                It.IsAny<CancellationToken>()), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ActionExecure_ReturnNoContentResult()
        {
            var guidEstate = Guid.NewGuid();
            var id = Guid.NewGuid();

            var result = await _controller.DeleteImageForEstate(guidEstate,id);

            _mockRepo.Verify(r => r.Send(
                It.IsAny<DeleteCountryImageCommand>(),
                It.IsAny<CancellationToken>()), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
