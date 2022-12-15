namespace IvanRealEstate.Test.HandlersTests.EstateTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Estate;
    using IvanRealEstate.Application.Handlers.EstateHandlers;
    using IvanRealEstate.Application.Commands.EstateCommands;

    public class CreateEstateHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _MockRepo;
        private readonly EstateForCreationDto _estateForCreationDto;

        public CreateEstateHandlerTests()
        {
            _MockRepo = MockEstateRepository.EstateRepositoryForTest();

            _mapper = MapperConfig.Configuration();

            _estateForCreationDto = new EstateForCreationDto
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
        }

        [Fact]
        public async Task Valid_CreateEstateHandler_Test()
        {
            var handler = new CreateEstateHandler(_MockRepo.Object, _mapper);

            var result =await handler.Handle(new CreateEstateCommand(_estateForCreationDto),CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<EstateDto>(result);

            Assert.Equal("Levski", result.Neighborhood);
            Assert.Equal("Bul.Vasil Levski", result.Address);
            Assert.Equal("With Nice Bars", result.Description);
            Assert.Equal("asansior, parking, magazin", result.Extras);

            Assert.True(2010 == result.YearOfCreation);
            Assert.True(259000 == result.Price);
            Assert.True(11 == result.Floоr);
            Assert.True(4 == result.Rooms);
            Assert.True(true == result.Sell);
        }


    }
}
