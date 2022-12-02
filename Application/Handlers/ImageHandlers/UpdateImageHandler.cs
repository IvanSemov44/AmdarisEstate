namespace IvanRealEstate.Application.Handlers.ImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Commands.ImageCommads;
    using IvanRealEstate.Application.Handlers.EstateHandlers;

    internal sealed class UpdateImageHandler : IRequestHandler<UpdateImageCommand, Unit>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateImageHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
        {
            await CheckerForEstate.CheckIfEstateExistAndReturnIt(_repositoryManager, request.EstateId, request.EstateTrackChanges);

            var image = await CheckerForImage.CheckIfImageExistAndReturnIt(_repositoryManager, request.EstateId, request.ImageId, request.ImageTrackChanges);

            _mapper.Map(request.ImageForUpdateDto, image);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
