namespace IvanRealEstate.Test.Controller
{
    using Moq;
    using MediatR;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Presentation.Controllers;
    using IvanRealEstate.Application.Queries.EstateQuery;
    using IvanRealEstate.Shared.DataTransferObject.Estate;
    using IvanRealEstate.Application.Commands.EstateCommands;

    public class EstateControllerTest
    {
        private readonly Mock<IMediator> _mockRepo;
        private readonly EstateController _controller;

        public EstateControllerTest()
        {
            _mockRepo = new Mock<IMediator>();
            _controller = new EstateController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetEstates_ActionExecute_ReturnOkObjectResultForGetEstates()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetEstatesQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var result = await _controller.GetAllEstate();

            _mockRepo.Verify(x => x.Send(It.IsAny<GetEstatesQuery>(), It.IsAny<CancellationToken>()));

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetEstates_ActionExecute_ReturnExactNumberOfEstates()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetEstatesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EstateDto>() { new EstateDto(), new EstateDto() });

            var result = await _controller.GetAllEstate();

            var resultObject = Assert.IsType<OkObjectResult>(result);
            var estates = Assert.IsType<List<EstateDto>>(resultObject.Value);
            Assert.Equal(2, estates.Count);
        }

        [Fact]
        public async Task GetEstateById_ActionExecute_GetEstateQueryIsCalled()
        {
            _mockRepo.Setup(r => r.Send(It.IsAny<GetEstateQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var guid = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");

            await _controller.GetEstate(guid);

            _mockRepo.Verify(r => r.Send(It.IsAny<GetEstateQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task GetEstateById_ActionExecute_GetEstateQueryWithCorrectEstateIdIsCalled()
        {
            var guid = Guid.NewGuid();

            _mockRepo.Setup(r => r.Send(It.IsAny<GetEstateQuery>(), It.IsAny<CancellationToken>()))
                 .Returns<GetEstateQuery, CancellationToken>(async (q, c) =>
                 {
                     guid = q.EstateId;
                     return await Task.FromResult(
                         new EstateDto
                         {
                             Neighborhood = "Levski",
                             Address = "Bul.Vasil Levski",
                             Description = "With Nice Bars",
                             YearOfCreation = 2010,
                             Price = 259000,
                             Floоr = 11,
                             Rooms = 4,
                             Extras = "asansior, parking, magazin",
                             Sell = true,
                             Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                             Changed = DateTime.Parse("2022-11-29T12:16:19.5468204"),
                             CityId = Guid.Parse("25db1981-7501-45bd-e3bd-08dacfa02b27"),
                             CurencyId = Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0"),
                             CountryId = Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656"),
                             EstateTypeId = Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662"),
                         });
                 });

            var estateId = new Guid("35db1981-7501-45bd-e3bd-08dacfa02b27");

            var result = await _controller.GetEstate(estateId);

            var resultObjerct = Assert.IsType<OkObjectResult>(result);

            var returnEstate = resultObjerct.Value as EstateDto;

            Assert.Equal((int)HttpStatusCode.OK, resultObjerct.StatusCode);
            Assert.Equal(guid.ToString(), estateId.ToString());
            Assert.Equal("Levski", returnEstate?.Neighborhood);
            Assert.Equal("Bul.Vasil Levski", returnEstate?.Address);
            Assert.Equal("With Nice Bars", returnEstate?.Description);
            Assert.Equal("asansior, parking, magazin", returnEstate?.Extras);

            Assert.True(2010 == returnEstate?.YearOfCreation);
            Assert.True(259000 == returnEstate?.Price);
            Assert.True(11 == returnEstate?.Floоr);
            Assert.True(4 == returnEstate?.Rooms);
            Assert.True(true == returnEstate?.Sell);
        }

        [Fact]
        public async Task Create_ActionExecure_ReturnCreatedAtRouteResult()
        {
            _mockRepo.Setup(r => r.Send(
                It.IsAny<CreateEstateCommand>(),
                It.IsAny<CancellationToken>()))
                  .ReturnsAsync(
                    new EstateDto
                    {
                        Neighborhood = "Levski",
                        Address = "Bul.Vasil Levski",
                        Description = "With Nice Bars",
                        YearOfCreation = 2010,
                        Price = 259000,
                        Floоr = 11,
                        Rooms = 4,
                        Extras = "asansior, parking, magazin",
                        Sell = true,
                        Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                        Changed = DateTime.Parse("2022-11-29T12:16:19.5468204"),
                        CityId = Guid.Parse("25db1981-7501-45bd-e3bd-08dacfa02b27"),
                        CurencyId = Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0"),
                        CountryId = Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656"),
                        EstateTypeId = Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662"),
                    }
                 );

            var estate = new EstateForCreationDto
            {
                Neighborhood = "Levski",
                Address = "Bul.Vasil Levski",
                Description = "With Nice Bars",
                YearOfCreation = 2010,
                Price = 259000,
                Floоr = 11,
                Rooms = 4,
                Extras = "asansior, parking, magazin",
                Sell = true,
                Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                Changed = DateTime.Parse("2022-11-29T12:16:19.5468204"),
                CityId = Guid.Parse("25db1981-7501-45bd-e3bd-08dacfa02b27"),
                CurencyId = Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0"),
                CountryId = Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656"),
                EstateTypeId = Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662"),
            };

            var result = await _controller.CreateEstate(estate);

            var resultRouteStatus = (result as CreatedAtRouteResult)?.StatusCode;

            var resultRouteDto = ((result as CreatedAtRouteResult)?.Value as EstateDto);

            Assert.IsType<CreatedAtRouteResult>(result);

            Assert.True((int)HttpStatusCode.Created == resultRouteStatus);
            Assert.Equal("Levski", resultRouteDto?.Neighborhood);
            Assert.Equal("Bul.Vasil Levski", resultRouteDto?.Address);
            Assert.Equal("With Nice Bars", resultRouteDto?.Description);
            Assert.Equal("asansior, parking, magazin", resultRouteDto?.Extras);

            Assert.True(2010 == resultRouteDto?.YearOfCreation);
            Assert.True(259000 == resultRouteDto?.Price);
            Assert.True(11 == resultRouteDto?.Floоr);
            Assert.True(4 == resultRouteDto?.Rooms);
            Assert.True(true == resultRouteDto?.Sell);
        }

        [Fact]
        public async Task Update_ActionExecure_ReturnNoContentResult()
        {
            var id = Guid.NewGuid();
            var city = new EstateForUpdateDto
            {

                Neighborhood = "Levski",
                Address = "Bul.Vasil Levski",
                Description = "With Nice Bars",
                YearOfCreation = 2010,
                Price = 259000,
                Floоr = 11,
                Rooms = 4,
                Extras = "asansior, parking, magazin",
                Sell = true,
                Created = DateTime.Parse("2022-11-29T12:16:19.5468059"),
                Changed = DateTime.Parse("2022-11-29T12:16:19.5468204"),
                CityId = Guid.Parse("25db1981-7501-45bd-e3bd-08dacfa02b27"),
                CurencyId = Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0"),
                CountryId = Guid.Parse("f8c5ce88-54ee-4feb-9605-08dad0620656"),
                EstateTypeId = Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662"),
            };

            var result = await _controller.UpdateEstate(id, city);

            _mockRepo.Verify(r => r.Send(
                It.IsAny<UpdateEstateCommand>(),
                It.IsAny<CancellationToken>()), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ActionExecure_ReturnNoContentResult()
        {
            var id = Guid.NewGuid();

            var result = await _controller.DeleteEstate(id);

            _mockRepo.Verify(r => r.Send(
                It.IsAny<DeleteEstateCommand>(),
                It.IsAny<CancellationToken>()), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
