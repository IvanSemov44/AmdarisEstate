namespace IvanRealEstate.Test.HandlersTests.EstateTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Estate;
    using IvanRealEstate.Application.Commands.EstateCommands;
    using IvanRealEstate.Application.Handlers.EstateHandlers;

    public class UpdateEstateHandlerTests
    {
        private readonly Guid _estateId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly EstateForUpdateDto _estateForUpdateDto;

        public UpdateEstateHandlerTests()
        {
            _mapper = MapperConfig.Configuration();
            _estateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670");
            _mockRepo = MockEstateRepository.EstateRepositoryForTest(_estateId);
            _estateForUpdateDto = new EstateForUpdateDto
            {
                Neighborhood = "Vladislavovo",
                Address = "Bl.407",
                Description = "Very Big",//update
                YearOfCreation = 2000,//update
                Price = 199000,
                Floоr = 8,//update
                Rooms = 5,
                Extras = "asansior i parking magazin",
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
        public async Task Valid_UpdateEstateHandler_Test()
        {
            var handler = new UpdateEstateHandler(_mockRepo.Object, _mapper);

            await handler.Handle(new UpdateEstateCommand(_estateId, _estateForUpdateDto, true),CancellationToken.None);

            var result = await _mockRepo.Object.Estate.GetEstateAsync(_estateId, false);

            Assert.True(_estateForUpdateDto.Floоr == result?.Floоr);
            Assert.True(_estateForUpdateDto.Description == result?.Description);
            Assert.True(_estateForUpdateDto.YearOfCreation == result?.YearOfCreation);
        }
    }
}
