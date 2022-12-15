

namespace IvanRealEstate.Test.Controller
{
    using Moq;
    using MediatR;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Presentation.Controllers;
    using IvanRealEstate.Application.Queries.EstateTypeQuery;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;
    using IvanRealEstate.Application.Commands.EstateTypeCommands;

    public class EstateTypeControllerTest
    {
        private readonly Mock<IMediator> _mockRepo;
        private readonly EstateTypeController _controller;

        public EstateTypeControllerTest()
        {
            _mockRepo = new Mock<IMediator>();
            _controller = new EstateTypeController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetEstateType_ActionExecute_ReturnOkObjectResultForGetEstateType()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetEstateTypesQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var result = await _controller.GetEstateTypes();

            _mockRepo.Verify(x => x.Send(It.IsAny<GetEstateTypesQuery>(), It.IsAny<CancellationToken>()));

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetEstateType_ActionExecute_ReturnExactNumberOfEstateType()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetEstateTypesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EstateTypeDto>() { new EstateTypeDto(), new EstateTypeDto() });

            var result = await _controller.GetEstateTypes();

            var resultObject = Assert.IsType<OkObjectResult>(result);
            var cities = Assert.IsType<List<EstateTypeDto>>(resultObject.Value);
            Assert.Equal(2, cities.Count);
        }


        [Fact]
        public async Task GetEstateTypeById_ActionExecute_GetEstateTypeQueryIsCalled()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetEstateTypeQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var guid = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");

            await _controller.GetEstateTypeById(guid);

            _mockRepo.Verify(r => r.Send(It.IsAny<GetEstateTypeQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task GetEstateTypeById_ActionExecute_GetEstateTypeQueryWithCorrectEstateTypeIdIsCalled()
        {
            var guid = Guid.NewGuid();

            _mockRepo.Setup(r => r.Send(It.IsAny<GetEstateTypeQuery>(), It.IsAny<CancellationToken>()))
                 .Returns<GetEstateTypeQuery, CancellationToken>(async (q, c) =>
                 {
                     guid = q.EstateTypeId;
                     return await Task.FromResult(
                         new EstateTypeDto
                         {
                             EstateTypeId = q.EstateTypeId,
                             TypeName = "House"
                         });
                 });

            var cityId = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");

            var result = await _controller.GetEstateTypeById(cityId);

            var resultObjerct = Assert.IsType<OkObjectResult>(result);

            Assert.Equal((int)HttpStatusCode.OK, resultObjerct.StatusCode);
            Assert.Equal("House", (resultObjerct.Value as EstateTypeDto)?.TypeName);
            Assert.Equal(guid.ToString(), cityId.ToString());
        }

        [Fact]
        public async Task Create_ActionExecure_ReturnCreatedAtRouteResult()
        {
            _mockRepo.Setup(r => r.Send(
                It.IsAny<CreateEstateTypeCommand>(),
                It.IsAny<CancellationToken>()))
                  .ReturnsAsync(
                    new EstateTypeDto
                    {
                        EstateTypeId = Guid.NewGuid(),
                        TypeName = "BGN"
                    }
                 );

            var currency = new EstateTypeForCreationDto { TypeName = "BGN" };

            var result = await _controller.CreateEstateType(currency);

            var resultRouteStatus = (result as CreatedAtRouteResult)?.StatusCode;
            var resultRouteDto = ((result as CreatedAtRouteResult)?.Value as EstateTypeDto);

            Assert.IsType<CreatedAtRouteResult>(result);
            Assert.True((int)HttpStatusCode.Created == resultRouteStatus);
            Assert.True(resultRouteDto?.TypeName == currency.TypeName);
        }

        [Fact]
        public async Task Update_ActionExecure_ReturnNoContentResult()
        {
            var id = Guid.NewGuid();
            var estateType = new EstateTypeForUpdateDto { TypeName = "Varna" };

            var result = await _controller.UpdateEstateType(id, estateType);

            _mockRepo.Verify(r => r.Send(
                It.IsAny<UpdateEstateTypeCommand>(),
                It.IsAny<CancellationToken>()), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ActionExecure_ReturnNoContentResult()
        {
            var id = Guid.NewGuid();

            var result = await _controller.DeleteEstateType(id);

            _mockRepo.Verify(r => r.Send(
                It.IsAny<DeleteEstateTypeCommand>(),
                It.IsAny<CancellationToken>()), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
