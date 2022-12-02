

using AutoMapper;
using IvanRealEstate.Application.Handlers.EstateHandlers;
using IvanRealEstate.Application.Queries.EstateQuery;
using IvanRealEstate.Contracts;
using IvanRealEstate.Shared.DataTransferObject.Estate;
using Moq;

namespace IvanRealEstate.Test.HandlersTests.EstateTests
{
    public class GetEstateHandlerTest
    {
        private readonly Guid _estateId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetEstateHandlerTest()
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
        public async Task Valid_GetEstate_Test()
        {
            var handler = new GetEstateHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetEstateQuery(_estateId, false),CancellationToken.None);

            Assert.NotNull(result);
            Assert.Contains("Vladislavovo", result.Neighborhood);
            Assert.Contains("Golqm e", result.Description);
            Assert.IsType<EstateDto>(result);

        }
    }
}
