namespace IvanRealEstate.Test.Controller
{
    using Moq;
    using MediatR;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Presentation.Controllers;
    using IvanRealEstate.Application.Queries.CountryQueries;
    using IvanRealEstate.Shared.DataTransferObject.Country;
    using IvanRealEstate.Application.Commands.CountryCommands;

    public class CountryControllerTest
    {
        private readonly Mock<IMediator> _mockRepo;
        private readonly CountryController _controller;

        public CountryControllerTest()
        {
            _mockRepo = new Mock<IMediator>();
            _controller = new CountryController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetCountries_ActionExecute_ReturnOkObjectResultForGetCountries()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetCountriesQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var result = await _controller.GetCountries();

            _mockRepo.Verify(x => x.Send(It.IsAny<GetCountriesQuery>(), It.IsAny<CancellationToken>()));

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetCountries_ActionExecute_ReturnExactNumberOfCountries()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetCountriesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<CountryDto>() { new CountryDto(), new CountryDto() });

            var result = await _controller.GetCountries();

            var resultObject = Assert.IsType<OkObjectResult>(result);
            var cities = Assert.IsType<List<CountryDto>>(resultObject.Value);
            Assert.Equal(2, cities.Count);
        }

        [Fact]
        public async Task GetCountryById_ActionExecute_GetCountryQueryIsCalled()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetCountryQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var guid = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");

            await _controller.GetCountryById(guid);

            _mockRepo.Verify(r => r.Send(It.IsAny<GetCountryQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task GetCountryById_ActionExecute_GetCountryQueryWithCorrectCityIdIsCalled()
        {
            var guid = Guid.NewGuid();

            _mockRepo.Setup(r => r.Send(It.IsAny<GetCountryQuery>(), It.IsAny<CancellationToken>()))
                 .Returns<GetCountryQuery, CancellationToken>(async (q, c) =>
                 {
                     guid = q.CountryId;
                     return await Task.FromResult(
                         new CountryDto
                         {
                             CountryId = q.CountryId,
                             CountryName = "Bulgaria"
                         });
                 });

            var cityId = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");

            var result = await _controller.GetCountryById(cityId);

            var resultObjerct = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, resultObjerct.StatusCode);
            Assert.Equal("Bulgaria", (resultObjerct.Value as CountryDto)?.CountryName);
            Assert.Equal(guid.ToString(), cityId.ToString());
        }

        [Fact]
        public async Task Create_ActionExecure_ReturnCreatedAtRouteResult()
        {
            _mockRepo.Setup(r => r.Send(
                It.IsAny<CreateCountryCommand>(),
                It.IsAny<CancellationToken>()))
                  .ReturnsAsync(
                    new CountryDto
                    {
                        CountryId = Guid.NewGuid(),
                        CountryName = "Varna"
                    }
                 );

            var city = new CountryForCreationDto { CountryName = "Varna" };

            var result = await _controller.CreateCountry(city);

            var resultRouteStatus = (result as CreatedAtRouteResult)?.StatusCode;
            var resultRouteDto = ((result as CreatedAtRouteResult)?.Value as CountryDto);

            Assert.IsType<CreatedAtRouteResult>(result);
            Assert.True((int)HttpStatusCode.Created == resultRouteStatus);
            Assert.True(resultRouteDto?.CountryName == city.CountryName);
        }

        [Fact]
        public async Task Update_ActionExecure_ReturnNoContentResult()
        {
            var id = Guid.NewGuid();
            var country = new CountryForUpdateDto { CountryName = "Varna" };

            var result = await _controller.UpdateCountry(id, country);

            _mockRepo.Verify(r => r.Send(
                It.IsAny<UpdateCountryCommand>(),
                It.IsAny<CancellationToken>()), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ActionExecure_ReturnNoContentResult()
        {
            var id = Guid.NewGuid();

            var result = await _controller.DeleteCountry(id);

            _mockRepo.Verify(r => r.Send(
                It.IsAny<DeleteCountryCommand>(),
                It.IsAny<CancellationToken>()), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
