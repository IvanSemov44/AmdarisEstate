namespace IvanRealEstate.Test.HandlersTests.CurrencyTest
{
    using Moq;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.CurrencyHandlers;
    using IvanRealEstate.Application.Queries.CurrencyQueries;
    using IvanRealEstate.Shared.DataTransferObject.Currency;

    public class GetCurrenciesHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryManager> _mockRepo;

        public GetCurrenciesHandlerTest()
        {
            _mapper = MapperConfig.Configuration();
            _mockRepo = MockCurrencyRepository.CurrencyRepositoryForTest();
        }

        [Fact]
        public async Task Valid_GetCurrenciesHandlerTest()
        {
            var handler = new GetCurrenciesHandler(_mockRepo.Object,_mapper);
            var result = await handler.Handle(new GetCurrenciesQuery(TrackChanges: false),
                CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<List<CurrencyDto>>(result);
            Assert.True(result.Count() == 3);
        }

        [Fact]
        public async Task Invalid_GetCurrenciesHandlerTest()
        {
            var handler = new GetCurrenciesHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetCurrenciesQuery(TrackChanges: false),
                CancellationToken.None);

            Assert.False(result.Count() == 4);
        }
    }
}
