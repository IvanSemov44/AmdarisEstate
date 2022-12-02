namespace IvanRealEstate.Application.Handlers.EstateHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.EstateCommands;

    internal sealed class UpdateEstateHandler : IRequestHandler<UpdateEstateCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateEstateHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateEstateCommand request, CancellationToken cancellationToken)
        {
            var estate = await CheckerForEstate.CheckIfCurrencyExistAndReturnIt(_repositoryManager, request.EstateId, request.TrackChanges);

            _mapper.Map(request.EstateForUpdateDto, estate);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
