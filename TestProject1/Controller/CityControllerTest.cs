using IvanRealEstate.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Xml.Serialization;

namespace IvanRealEstate.Test.Controller
{
    public class CityControllerTest
    {
        private readonly Mock<ISender> _mockRepo;
        private readonly CityController _controller;

        public CityControllerTest()
        {
            _mockRepo = new Mock<ISender>();
            _controller = new CityController(_mockRepo.Object);
        }

        [Fact]
        public async void GetCity_ActionExecute_ReturnOkObjectResultForGetCity()
        {
            var guid = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");
            var result = await _controller.GetCity(guid);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetCities_ActionExecute_ReturnExactNumberOfCities()
        {

        }

    }
}
