namespace IvanRealEstate.Test.HandlersTests.EstateTypeTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Queries.EstateTypeQuery;
    using IvanRealEstate.Application.Handlers.EstateTypeHandler;

    public class GetEstateTypesHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetEstateTypesHandlerTests()
        {
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockEstateTypeRepository.EstateTypeRepository();
        }

        [Fact]
        public async Task Valid_GetEstateTypeHandlerTest()
        {
            var handler = new GetEstateTypesHandler(_mockRepo.Object, _mapper);
            var result = await handler
                .Handle(new GetEstateTypesQuery(TrackChanges: false), CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.Count() == 3);
        }
    }
}
