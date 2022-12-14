namespace IvanRealEstate.Test.HandlersTests.EstateTypeTests
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;
    using IvanRealEstate.Application.Handlers.EstateTypeHandler;
    using IvanRealEstate.Application.Commands.EstateTypeCommands;

    public class CreateEstateTypeHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly EstateTypeForCreationDto _estateTypeForCreationDto;

        public CreateEstateTypeHandlerTest()
        {
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockEstateTypeRepository.EstateTypeRepository();
            _estateTypeForCreationDto = new EstateTypeForCreationDto { TypeName = "Rural" }; 
        }

        [Fact]
        public async Task Valid_CreateEstateTypeHandlerTest()
        {
            var handler = new CreateEstateTypeHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new CreateEstateTypeCommand(_estateTypeForCreationDto),
                CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<EstateTypeDto>(result);
            Assert.True(result.TypeName == _estateTypeForCreationDto.TypeName);
        }
    }
}
