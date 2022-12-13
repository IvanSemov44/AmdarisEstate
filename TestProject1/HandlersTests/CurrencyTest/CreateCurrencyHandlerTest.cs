namespace IvanRealEstate.Test.HandlersTests.CurrencyTest
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.CurrencyHandlers;
    using IvanRealEstate.Application.Commands.CurrencyCommands;
    using IvanRealEstate.Shared.DataTransferObject.Currency;

    public class CreateCurrencyHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly CurrencyForCreationDto _currencyForCreationDto;

        public CreateCurrencyHandlerTest()
        {
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockCurrencyRepository.CurrencyRepositoryForTest();
            _currencyForCreationDto = new CurrencyForCreationDto
            {
                CurrencyName = "INR"
            };
        }

        [Fact]
        public async Task Valid_CreateCurrencyHandleTest()
        {
            var handler = new CreateCurrencyHandler(_mockRepo.Object, _mapper);
            var result = await handler
                .Handle(new CreateCurrencyCommand(_currencyForCreationDto), CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<CurrencyDto>(result);
            Assert.Equal(_currencyForCreationDto.CurrencyName, result.CurrencyName);
        }
    
    }
}
