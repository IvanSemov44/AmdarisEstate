namespace IvanRealEstate.Test.HandlersTests.CurrencyTest
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.CurrencyHandlers;
    using IvanRealEstate.Application.Queries.CurrencyQueries;
    using IvanRealEstate.Shared.DataTransferObject.Currency;

    public class GetCurrencyHandlerTest
    {
        private readonly Guid _currencyId;
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetCurrencyHandlerTest()
        {
            _currencyId = Guid.Parse("4bb67d01-13cb-47d5-d499-08dad1453af0");
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockCurrencyRepository.CurrencyRepositoryForTest(_currencyId);
        }

        [Fact]
        public async Task Valid_GetCurrencyHandlerTest()
        {
            var handler = new GetCurrencyHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetCurrencyQuery(_currencyId, TrackChanges: false),
                CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<CurrencyDto>(result);
            Assert.Contains("Euro", result.CurrencyName);
            Assert.Contains("4bb67d01-13cb-47d5-d499-08dad1453af0", result.CurrencyId.ToString());   
        }
    }
}
