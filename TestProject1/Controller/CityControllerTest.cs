using AutoMapper;
using IvanRealEstate.Application.Handlers.CityHandlers;
using IvanRealEstate.Application.Queries.CityQueties;
using IvanRealEstate.Contracts;
using IvanRealEstate.Entities.Models;
using IvanRealEstate.Presentation.Controllers;
using IvanRealEstate.Shared.DataTransferObject.City;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Xml.Serialization;

namespace IvanRealEstate.Test.Controller
{
    public class CityControllerTest
    {
        //private readonly IMapper _mapper;
        private readonly Mock<ISender> _mockRepo;
        private readonly CityController _controller;
        //private readonly Mock<ICityRepository> _city;


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

        //[Fact]
        //public async void GetCities_ActionExecute_ReturnExactNumberOfCities()
        //{
        //    var handler = new GetCitiesHandler(_city,)

        //        await _mockRepo.Setup(repo => repo.Send(new GetCitiesQuery(false)))
        //                .Returns(ISender sender, new List<CityDto>() { new CityDto(), new CityDto() });
        //}

    }
}
