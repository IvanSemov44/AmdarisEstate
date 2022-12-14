namespace IvanRealEstate.Application.Handlers.EstateTypeHandler
{

    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Queries.EstateTypeQuery;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;

    public sealed class GetEstateTypeHandler : IRequestHandler<GetEstateTypeQuery, EstateTypeDto>
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
            var estateType = await CheckerForEstateType.CheckIfEstateTypeExistAndReturnIt(_repositoryManager, request.EstateTypeId, request.TrackChanges);

            var estateTypeForReturn = _mapper.Map<EstateTypeDto>(estateType);

            return estateTypeForReturn;
        }
    }
}
