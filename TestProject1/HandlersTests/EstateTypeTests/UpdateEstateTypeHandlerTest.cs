namespace IvanRealEstate.Test.HandlersTests.EstateTypeTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;
    using IvanRealEstate.Application.Commands.EstateTypeCommands;
    using IvanRealEstate.Application.Handlers.EstateTypeHandler;

    public class UpdateEstateTypeHandlerTest
    {
        private readonly Guid _estateTypeId;
        private readonly EstateTypeForUpdateDto _estateTypeForUpdateDto;

        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;


        public UpdateEstateTypeHandlerTest()
        {
            _estateTypeId = Guid.Parse("f9fec971-f109-4679-0c67-08dad1555662");
            _estateTypeForUpdateDto = new EstateTypeForUpdateDto { TypeName = "Townhouse" };

            _mapper = MapperConfig.Configuration();
            _mockRepo = MockEstateTypeRepository.EstateTypeRepository(_estateTypeId);
        }

        [Fact]
        public async Task Valid_UpdateEstateTypeHadnlerTest()
        {
            var handler = new UpdateEstateTypeHandler(_mockRepo.Object, _mapper);
            await handler
                .Handle(new UpdateEstateTypeCommand(_estateTypeId, _estateTypeForUpdateDto, TrackChanges: true), CancellationToken.None);

            var result = await _mockRepo.Object.EstateType.GetEstateTypeAsync(_estateTypeId, trackChanges: false);

            Assert.NotNull(result);
            Assert.True(result?.TypeName == _estateTypeForUpdateDto.TypeName);
            Assert.True(result?.EstateTypeId == _estateTypeId);
        }
    }
}
