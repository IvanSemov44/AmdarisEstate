namespace IvanRealEstate.Application.Handlers.OwnerImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.EstateHandlers;
    using IvanRealEstate.Application.Commands.OwnerImageCommands;

    public sealed class UpdateOwnerImageHandler : IRequestHandler<UpdateOwnerImageCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateOwnerImageHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateOwnerImageCommand request, CancellationToken cancellationToken)
        {
            var image = await CheckerForOwnerImage.CheckIfOwnerImageExistAndReturnIt
                (_repositoryManager, request.OwnerId, request.OwnerImageId, request.OwnerImageTrackChanges);

            _mapper.Map(request.OwnerImageForUpdateDto, image);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
