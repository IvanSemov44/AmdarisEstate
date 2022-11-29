namespace IvanRealEstate.Application.Handlers.ImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using IvanRealEstate.Application.Queries.ImageQuery;

    internal sealed class GetImageHandler : IRequestHandler<GetImageQuery, ImageDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetImageHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<ImageDto> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            var estate = await _repositoryManager.Estate.GetEstateAsync(request.EstateId, request.TrackChanges);
            if (estate is null)
                throw new EstateNotFoundException(request.EstateId);

            var image = await _repositoryManager.Image.GetImageAsync(request.EstateId,request.ImageId, request.TrackChanges);
            if (image is null)
                throw new ImageNotFoundException(request.ImageId);

            var imageForReturn = _mapper.Map<ImageDto>(image);

            return imageForReturn;
        }
    }
}
