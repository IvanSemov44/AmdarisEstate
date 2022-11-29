namespace IvanRealEstate.Application.Handlers.ImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Application.Queries.ImageQuery;
    using IvanRealEstate.Shared.DataTransferObject.Image;

    internal sealed class GetImagesHandler : IRequestHandler<GetImagesQuery,IEnumerable<ImageDto>>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetImagesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<ImageDto>> Handle(GetImagesQuery request, CancellationToken cancellationToken)
        {
            var estate = await _repositoryManager.Estate.GetEstateAsync(request.EstateId, request.TrackChanges);
            if (estate is null)
                throw new EstateNotFoundException(request.EstateId);

            var imagesForEstate = await _repositoryManager.Image.GetImagesAsync(request.EstateId,request.TrackChanges);

            var imageForReturn = _mapper.Map<IEnumerable<ImageDto>>(imagesForEstate);

            return imageForReturn;
        }
    }
}
