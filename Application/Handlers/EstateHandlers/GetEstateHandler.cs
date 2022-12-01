namespace IvanRealEstate.Application.Handlers.EstateHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Application.Queries.EstateQuery;
    using IvanRealEstate.Shared.DataTransferObject.Estate;
    using IvanRealEstate.Shared.DataTransferObject.Image;

    internal sealed class GetEstateHandler : IRequestHandler<GetEstateQuery, EstateDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetEstateHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<EstateDto> Handle(GetEstateQuery request, CancellationToken cancellationToken)
        {
            var estate = await _repositoryManager.Estate.GetEstateAsync(request.EstateId, request.TrackChanges);
            if (estate is null)
                throw new EstateTypeNotFoundException(request.EstateId);

            var images = await _repositoryManager.Image.GetImagesAsync(request.EstateId, request.TrackChanges);

            var imagesForReturn = _mapper.Map<IEnumerable<ImageDto>>(images);

            var estateForReturn = _mapper.Map<EstateDto>(estate);

            estateForReturn.Images = imagesForReturn;

            return estateForReturn;
        }
    }
}
