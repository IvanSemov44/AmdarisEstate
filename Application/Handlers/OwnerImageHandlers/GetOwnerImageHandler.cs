namespace IvanRealEstate.Application.Handlers.OwnerImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.EstateHandlers;
    using IvanRealEstate.Application.Queries.OwnerImageQuery;
    using IvanRealEstate.Shared.DataTransferObject.OwnerImage;

    public sealed class GetOwnerImageHandler : IRequestHandler<GetOwnerImageQuery, OwnerImageDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetOwnerImageHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<OwnerImageDto> Handle(GetOwnerImageQuery request, CancellationToken cancellationToken)
        {
            var image = await CheckerForOwnerImage.CheckIfOwnerImageExistAndReturnIt
                (_repositoryManager, request.OwnerId, request.OwnerImageId, request.TrackChanges);

            var imageForReturn = _mapper.Map<OwnerImageDto>(image);

            return imageForReturn;
        }
    }
}
