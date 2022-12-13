namespace IvanRealEstate.Test.HandlersTests.CurrencyTest
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Currency;
    using IvanRealEstate.Application.Handlers.CurrencyHandlers;
    using IvanRealEstate.Application.Commands.CurrencyCommands;

    public class UpdateCurrencyHandlerTest
    {
        private readonly Guid _currencyId;
        private readonly CurrencyForUpdateDto _currencyForUpdateDto;

        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public UpdateCurrencyHandlerTest()
        {
            _currencyId = Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0");
            _currencyForUpdateDto = new CurrencyForUpdateDto
            {
                CurrencyName = "MKD"
            };

            _mapper = MapperConfig.Configuration();
            _mockRepo = MockCurrencyRepository.CurrencyRepositoryForTest(_currencyId);
        }

        [Fact]
        public async Task Valid_UpdateCurrencyHandlerTest()
        {
            var handler = new UpdateCurrencyHandler(_mockRepo.Object, _mapper);
            await handler
                .Handle(new UpdateCurrencyCommand(_currencyId, _currencyForUpdateDto, TrackChanges: true),
                CancellationToken.None);

            var result = await _mockRepo.Object.Currency.GetCurrencyAsync(_currencyId, trackChanges: false);

            Assert.NotNull(result);
            Assert.Equal(result?.CurrencyName, _currencyForUpdateDto.CurrencyName);
            Assert.Equal(result?.CurrencyId.ToString(), _currencyId.ToString());
        }
    }
}
