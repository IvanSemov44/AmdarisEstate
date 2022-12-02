
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
        private readonly Guid _estateId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetEstatesHandlerTest()
        {
            _estateId = Guid.Parse("387f6683-f763-4e0d-b35c-08dad2038670");

            _mockRepo = MockEstateRepository.EstateRepositoryForTest(_estateId);

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
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
