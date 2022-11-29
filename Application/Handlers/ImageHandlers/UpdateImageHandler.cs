namespace IvanRealEstate.Application.Handlers.ImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Application.Commands.ImageCommads;

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
            var estate = await _repositoryManager.Estate.GetEstateAsync(request.EstateId, request.EstateTrackChanges);
            if (estate is null)
                throw new EstateNotFoundException(request.EstateId);

            var image = await _repositoryManager.Image.GetImageAsync(request.EstateId,request.ImageId, request.ImageTrackChanges);
            if (image is null)
                throw new ImageNotFoundException(request.ImageId);

            _mapper.Map(request.ImageForUpdateDto, image);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
