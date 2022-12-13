namespace IvanRealEstate.Test.HandlersTests.EstateTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Queries.EstateQuery;
    using IvanRealEstate.Shared.DataTransferObject.Estate;
    using IvanRealEstate.Application.Handlers.EstateHandlers;

    public class GetEstatesHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetEstatesHandlerTest()
        {
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockEstateRepository.EstateRepositoryForTest();
        }

        [Fact]
        public async Task Valid_GetEstates_Test()
        {
            var handler = new GetEstatesHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetEstatesQuery(false), CancellationToken.None);

            Assert.IsAssignableFrom<List<EstateDto>>(result);
            Assert.True(result.Count() == 3);
        }
    }
}
