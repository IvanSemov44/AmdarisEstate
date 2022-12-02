namespace IvanRealEstate.Application.Handlers.EstateHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Queries.EstateQuery;
    using IvanRealEstate.Shared.DataTransferObject.Estate;

    internal sealed class GetEstatesHandler : IRequestHandler<GetEstatesQuery, IEnumerable<EstateDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetEstatesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<EstateDto>> Handle(GetEstatesQuery request, CancellationToken cancellationToken)
        {
            var estatesEntite = await _repositoryManager.Estate.GetAllEstatesAsync(request.TrackChanges);

            var estatesForReturn = _mapper.Map<IEnumerable<EstateDto>>(estatesEntite);

            return estatesForReturn;
        }
    }
}
