namespace IvanRealEstate.Application.Handlers.EstateTypeHandler
{

    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Application.Queries.EstateTypeQuery;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;

    internal sealed class GetEstateTypeHandler : IRequestHandler<GetEstateTypeQuery, EstateTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetEstateTypeHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<EstateTypeDto> Handle(GetEstateTypeQuery request, CancellationToken cancellationToken)
        {
            var estateType = await _repositoryManager.EstateType.GetEstateTypeAsync(request.EstateTypeID, request.TrackChanges);
            if (estateType is null)
                throw new EstateTypeNotFoundException(request.EstateTypeID);

            var estateTypeForReturn = _mapper.Map<EstateTypeDto>(estateType);

            return estateTypeForReturn;
        }
    }
}
