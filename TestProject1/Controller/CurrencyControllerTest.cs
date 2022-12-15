namespace IvanRealEstate.Test.Controller
{
    using Moq;
    using MediatR;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Presentation.Controllers;
    using IvanRealEstate.Application.Queries.CurrencyQueries;
    using IvanRealEstate.Shared.DataTransferObject.Currency;
    using IvanRealEstate.Application.Commands.CurrencyCommands;

    public class CurrencyControllerTest
    {

        private readonly Mock<IMediator> _mockRepo;
        private readonly CurrencyController _controller;

        public CurrencyControllerTest()
        {
            _mockRepo = new Mock<IMediator>();
            _controller = new CurrencyController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetCurrencies_ActionExecute_ReturnOkObjectResultForGetCurrencies()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetCurrenciesQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var result = await _controller.GetCurrencies();

            _mockRepo.Verify(x => x.Send(It.IsAny<GetCurrenciesQuery>(), It.IsAny<CancellationToken>()));

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetCurrencies_ActionExecute_ReturnExactNumberOfCurrencies()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetCurrenciesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<CurrencyDto>() { new CurrencyDto(), new CurrencyDto() });

            var result = await _controller.GetCurrencies();

            var resultObject = Assert.IsType<OkObjectResult>(result);
            var cities = Assert.IsType<List<CurrencyDto>>(resultObject.Value);
            Assert.Equal(2, cities.Count);
        }

        [Fact]
        public async Task GetCurrencyById_ActionExecute_GetCurrencyQueryIsCalled()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetCurrencyQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var guid = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");

            await _controller.GetCurrencyById(guid);

            _mockRepo.Verify(r => r.Send(It.IsAny<GetCurrencyQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task GetCurrencyById_ActionExecute_GetCurrencyQueryWithCorrectCurrencyIdIsCalled()
        {
            var guid = Guid.NewGuid();

            _mockRepo.Setup(r => r.Send(It.IsAny<GetCurrencyQuery>(), It.IsAny<CancellationToken>()))
                 .Returns<GetCurrencyQuery, CancellationToken>(async (q, c) =>
                 {
                     guid = q.CurrencyId;
                     return await Task.FromResult(
                         new CurrencyDto
                         {
                             CurrencyId = q.CurrencyId,
                             CurrencyName = "BGN"
                         });
                 });

            var cityId = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");

            var result = await _controller.GetCurrencyById(cityId);

            var resultObjerct = Assert.IsType<OkObjectResult>(result);

            Assert.Equal((int)HttpStatusCode.OK, resultObjerct.StatusCode);
            Assert.Equal("BGN", (resultObjerct.Value as CurrencyDto)?.CurrencyName);
            Assert.Equal(guid.ToString(), cityId.ToString());
        }

        [Fact]
        public async Task Create_ActionExecure_ReturnCreatedAtRouteResult()
        {
            _mockRepo.Setup(r => r.Send(
                It.IsAny<CreateCurrencyCommand>(),
                It.IsAny<CancellationToken>()))
                  .ReturnsAsync(
                    new CurrencyDto
                    {
                        CurrencyId = Guid.NewGuid(),
                        CurrencyName = "BGN"
                    }
                 );

            var currency = new CurrencyForCreationDto { CurrencyName = "BGN" };

            var result = await _controller.CreateCurrency(currency);

            var resultRouteStatus = (result as CreatedAtRouteResult)?.StatusCode;
            var resultRouteDto = ((result as CreatedAtRouteResult)?.Value as CurrencyDto);

            Assert.IsType<CreatedAtRouteResult>(result);
            Assert.True((int)HttpStatusCode.Created == resultRouteStatus);
            Assert.True(resultRouteDto?.CurrencyName == currency.CurrencyName);
        }

        [Fact]
        public async Task Update_ActionExecure_ReturnNoContentResult()
        {
            var id = Guid.NewGuid();
            var currency = new CurrencyForUpdateDto { CurrencyName = "Varna" };

            var result = await _controller.UpdateCurrency(id, currency);

            _mockRepo.Verify(r => r.Send(
                It.IsAny<UpdateCurrencyCommand>(),
                It.IsAny<CancellationToken>()), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ActionExecure_ReturnNoContentResult()
        {
            var id = Guid.NewGuid();

            var result = await _controller.DeleteCurrency(id);

            _mockRepo.Verify(r => r.Send(
                It.IsAny<DeleteCurrencyCommand>(),
                It.IsAny<CancellationToken>()), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
