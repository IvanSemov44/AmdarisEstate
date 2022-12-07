namespace IvanRealEstate.Application.Handlers.EstateHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Shared.RequestFeatures;
    using IvanRealEstate.Shared.DataTransferObject.Estate;
    using IvanRealEstate.Application.Queries.EstateQuery;

    internal sealed class GetEstatesByPage
        : IRequestHandler<GetEstatesByPageQuery, (IEnumerable<EstateDto> estatesDto, MetaData? metaData)>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetEstatesByPage(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<(IEnumerable<EstateDto> estatesDto, MetaData? metaData)> Handle(GetEstatesByPageQuery request, CancellationToken cancellationToken)
        {
            if (!request.EstateParameters.ValidYearRange)
                throw new MaxYearRangeBadRequestException();

            var estatesWithMetaData = await _repositoryManager.Estate
                .GetEstatesForPageAsync(request.EstateParameters, request.TrackChanges);

            var estateForReturn = _mapper.Map<IEnumerable<EstateDto>>(estatesWithMetaData);

            return (estatesDto: estateForReturn, metaData: estatesWithMetaData.MetaData);
        }

    }
}
