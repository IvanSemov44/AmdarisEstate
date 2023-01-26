namespace IvanRealEstate.Application.Handlers.OwnerImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.EstateHandlers;
    using IvanRealEstate.Application.Queries.OwnerImageQuery;
    using IvanRealEstate.Shared.DataTransferObject.OwnerImage;

    public sealed class GetAllOwnerImagesHandler : IRequestHandler<GetAllOwnerImagesQuery, IEnumerable<OwnerImageDto>>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetAllOwnerImagesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<OwnerImageDto>> Handle(GetAllOwnerImagesQuery request, CancellationToken cancellationToken)
        {
            var imagesForEstate = await _repositoryManager.OwnerImage.GetOwnerImagesAsync(request.OwnerId, request.TrackChanges);

            var imageForReturn = _mapper.Map<IEnumerable<OwnerImageDto>>(imagesForEstate);

            return imageForReturn;
        }
    }
}
