namespace IvanRealEstate.Application.Handlers.ImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using IvanRealEstate.Application.Commands.ImageCommads;

    internal sealed class CreateImageHandler : IRequestHandler<CreateImageCommand, ImageDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
            
        public CreateImageHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<ImageDto> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var estate = await _repositoryManager.Estate.GetEstateAsync(request.EstateId, request.TrackChanges);
            if (estate is null)
                throw new EstateNotFoundException(request.EstateId);

            var image = _mapper.Map<Image>(request.ImageForCreationDto);

            _repositoryManager.Image.CreateImage(request.EstateId, image);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<ImageDto>(image);
        }
    }
}
