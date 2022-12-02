namespace IvanRealEstate.Application.Handlers.EstateTypeHandler
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.EstateTypeCommands;

    internal sealed class UpdateEstateTypeHandler : IRequestHandler<UpdateEstateTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateEstateTypeHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateEstateTypeCommand request, CancellationToken cancellationToken)
        {
            var estateEntity = await CheckerForEstateType.CheckIfEstateTypeExistAndReturnIt(_repositoryManager, request.EstateTypeId, request.TrackChanges);

            _mapper.Map(request.EstateTypeForUpdateDto, estateEntity);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
