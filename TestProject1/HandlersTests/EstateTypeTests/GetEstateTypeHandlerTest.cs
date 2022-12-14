namespace IvanRealEstate.Test.HandlersTests.EstateTypeTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.EstateTypeHandler;
    using IvanRealEstate.Application.Queries.EstateTypeQuery;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;

    public class GetEstateTypeHandlerTest
    {
        private readonly Guid _estateTypeId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetEstateTypeHandlerTest()
        {
            _estateTypeId = Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662");
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockEstateTypeRepository.EstateTypeRepository(_estateTypeId);
        }

        [Fact]
        public async Task Valid_GetEstateTypeHandlerTest()
        {
            var handler = new GetEstateTypeHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetEstateTypeQuery(_estateTypeId, TrackChanges: false),
                CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<EstateTypeDto>(result);
            Assert.True(result.TypeName == "Apartment");
            Assert.True(result.EstateTypeId == _estateTypeId);
        }
    }
}
