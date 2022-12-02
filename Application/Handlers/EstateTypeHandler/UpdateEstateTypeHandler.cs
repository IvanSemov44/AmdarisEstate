namespace IvanRealEstate.Application.Handlers.EstateTypeHandler
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
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
            var estateEntity = await _repositoryManager.EstateType.GetEstateTypeAsync(request.EstateTypeId, request.TrackChanges);
            if (estateEntity is null)
                throw new EstateTypeNotFoundException(request.EstateTypeId);

            _mapper.Map(request.EstateTypeForUpdateDto, estateEntity);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
