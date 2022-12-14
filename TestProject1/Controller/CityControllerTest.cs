namespace IvanRealEstate.Test.Controller
{
    using Moq;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Presentation.Controllers;
    using IvanRealEstate.Application.Queries.CityQueties;
    using IvanRealEstate.Shared.DataTransferObject.City;

    public class CityControllerTest
    {
        private readonly Mock<IMediator> _mockRepo;
        private readonly CityController _controller;


        public CityControllerTest()
        {
            _mockRepo = new Mock<IMediator>();
            _controller = new CityController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetCities_ActionExecute_ReturnOkObjectResultForGetCity()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetCitiesQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var result = await _controller.GetCities();
            _mockRepo.Verify(x => x.Send(It.IsAny<GetCitiesQuery>(), It.IsAny<CancellationToken>()));

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetCities_ActionExecute_ReturnExactNumberOfCities()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetCitiesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<CityDto>() { new CityDto(), new CityDto() });

            var result = await _controller.GetCities();

            var resultObject = Assert.IsType<OkObjectResult>(result);
            var cities = Assert.IsType<List<CityDto>>(resultObject.Value);
            Assert.Equal(2, cities.Count);
        }

        [Fact]
        public async Task GetCityById_ActionExecute_GetCityQueryIsCalled()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetCityQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var guid = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");

            await _controller.GetCity(guid);

            _mockRepo.Verify(r => r.Send(It.IsAny<GetCityQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task GetCityById_ActionExecute_GetCityQueryWithCorrectCityIdIsCalled()
        {
            var guid = Guid.NewGuid();

            _mockRepo.Setup(r => r.Send(It.IsAny<GetCityQuery>(), It.IsAny<CancellationToken>()))
                 .Returns<GetCityQuery, CancellationToken>(async (q, c) =>
                 {
                     guid = q.CityId;
                     return await Task.FromResult(
                         new CityDto
                         {
                             CityId = q.CityId,
                             CityName = "Varna"
                         });
                 });

            var cityId = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");

            var result = await _controller.GetCity(cityId);

            var resultObjerct = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Varna",(resultObjerct.Value as CityDto)?.CityName);
            Assert.Equal(guid.ToString(), cityId.ToString());
        }



        //[Fact]
        //public async Task GetCity_ActionExecute_ReturnNotOkObjectResultForGetCity()
        //{
        //    var guid = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b23");
        //    var result = await _controller.GetCity(guid);

        //    Assert.IsType<OkObjectResult>(result);
        //}

        //[Fact]
        //public async void GetCities_ActionExecute_ReturnExactNumberOfCities()
        //{
        //    var handler = new GetCitiesHandler(_city,)

        //        await _mockRepo.Setup(repo => repo.Send(new GetCitiesQuery(false)))
        //                .Returns(ISender sender, new List<CityDto>() { new CityDto(), new CityDto() });
        //}

    }
}
