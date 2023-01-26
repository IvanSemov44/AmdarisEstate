namespace IvanRealEstate.Application.Handlers.ImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.DataTransferObject.Image;
    using IvanRealEstate.Application.Queries.ImageQuery;
    using IvanRealEstate.Application.Handlers.EstateHandlers;

    public sealed class GetImageHandler : IRequestHandler<GetImageQuery, ImageDto>
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
            await CheckerForEstate.CheckIfEstateExistAndReturnIt(_repositoryManager, request.EstateId, request.TrackChanges);

            var image = await CheckerForCompanyImage.CheckIfImageExistAndReturnIt(_repositoryManager, request.EstateId, request.ImageId, request.TrackChanges);

            var imageForReturn = _mapper.Map<ImageDto>(image);

            return imageForReturn;
        }
    }
}
