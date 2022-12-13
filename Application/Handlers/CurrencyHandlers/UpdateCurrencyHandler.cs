namespace IvanRealEstate.Application.Handlers.CurrencyHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.CurrencyCommands;

    public sealed class UpdateCurrencyHandler : IRequestHandler<UpdateCurrencyCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateCurrencyHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = await CheckerForCurrency.CheckIfCurrencyExistAndReturnIt(_repositoryManager, request.CurrencyId, request.TrackChanges);

            _mapper.Map(request.CurrencyForUpdateDto, currency);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
