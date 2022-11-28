namespace IvanRealEstate.Application.Handlers.CurrencyHandlers
{
    using MediatR;
    using AutoMapper;
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities;
    using IvanRealEstate.Application.Commands.CurrencyCommands;

    internal sealed class UpdateCurrencyHandler : IRequestHandler<UpdateCurrencyCommand, Unit>
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
            var currency = await _repositoryManager.Currency.GetCurrencyAsync(request.CurrencyId, request.TrackChanges);
            if (currency is null)
                throw new CurrencyNotFoundException(request.CurrencyId);

            _mapper.Map(request.CurrencyForUpdateDto, currency);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
